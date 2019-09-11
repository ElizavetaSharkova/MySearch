using System;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySearch.Models;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MySearch.Controllers
{
    public struct ParseResponseStruct
    {
        public SearchEngine engine;
        public HttpWebResponse webResponse;
    }

    public class HomeController : Controller
    {
        private readonly DbEditor db;

        public HomeController(DbEditor db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchTerm)
        {
            IQueryable<SearchEngine> searchEngines = db.GetEngines();
            List<Task<ParseResponseStruct>> responses = new List<Task<ParseResponseStruct>>();
            foreach (SearchEngine engine in searchEngines)
            {
                if (!engine.IsDisable)
                {
                    responses.Add(Task.Run(() => SendWebRequestAsync(searchTerm, engine)));
                }
            }
            ParseResponseStruct fasterResponse = await Task.WhenAny(responses).Result;
            List<SearchResult> results = ParseResponse(fasterResponse);

            AddToDb(searchTerm, results);
            ViewBag.searchString = searchTerm;
            ViewBag.results = results;
            ViewBag.isDisplayEngine = true;
            return View();
        }

        [HttpPost]
        public IActionResult History(string searchTerm)
        {
            List<SearchResult> results = db.GetResultsByRequest(searchTerm).ToList();
            ViewBag.searchString = searchTerm;
            ViewBag.results = results;
            return View();
        }

        private void AddToDb(string requestString, List<SearchResult> results)
        {
            SearchRequest request = new SearchRequest
            {
                SearchRequestId = default,
                SearchString = requestString,
                SearchDate = DateTime.Now,
                SearchResults = results
            };

            db.SaveRequest(request);
        }

        private HttpWebRequest BuildRequestToEngine(string searchQuery, SearchEngine engine)
        {
            string completeUrl = engine.BaseUrl;
            foreach (RequestsParameter parameter in engine.Parameters)
            {
                if (parameter.ParametrName == "search")
                {
                    completeUrl += parameter.ParametrValue + "=" + Uri.EscapeDataString(searchQuery);
                }
                else
                {
                    completeUrl += parameter.ParametrName + "=" + parameter.ParametrValue;
                }

                if (parameter != engine.Parameters.Last<RequestsParameter>())
                {
                    completeUrl += "&";
                }
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(completeUrl);

            if (engine.Headers != null)
            {
                foreach (RequestHeader header in engine.Headers)
                {
                    if (header.HeaderValue != string.Empty)
                    {
                        request.Headers[header.HeaderName] = header.HeaderValue;
                    }
                }
            }


            return request;
        }

        /// <summary>
        /// Makes a request to the any API and returns data as a ParseResponseStruct with response and engine.
        /// </summary>
        private async Task<ParseResponseStruct> SendWebRequestAsync(string searchQuery, SearchEngine engine)
        {
            HttpWebRequest request = BuildRequestToEngine(searchQuery, engine);
            HttpWebResponse response = (HttpWebResponse) await request.GetResponseAsync();
            foreach (string responseHeader in response.Headers)
            {
                foreach (RequestHeader requestHeader in engine.Headers)
                {
                    if (responseHeader.Contains(requestHeader.HeaderName.Substring(0, 9)) && 
                        string.IsNullOrEmpty(requestHeader.HeaderValue))
                    {
                        requestHeader.HeaderValue = responseHeader;
                        db.SaveRequestHeaderValue(requestHeader.RequestHeaderId, responseHeader);
                    }
                }
            }

            ParseResponseStruct prs = new ParseResponseStruct
            {
                webResponse = response,
                engine = engine
            };

            return prs;
        }

        /// <summary>
        /// Read response, call parse method according to response type and returns data as a List of SearchResult.
        /// </summary>
        public static List<SearchResult> ParseResponse(ParseResponseStruct prs)
        { 
            if (prs.engine.Type.Type == "xml")
            {
                XmlReader xmlReader = XmlReader.Create(prs.webResponse.GetResponseStream());
                XDocument xmlResponse = XDocument.Load(xmlReader);

                return ParseXml(xmlResponse, prs.engine);
            }
            else if (prs.engine.Type.Type == "json")
            {
                string responseString;
                using (Stream responseStream = prs.webResponse.GetResponseStream())
                {
                    responseString = new StreamReader(responseStream).ReadToEnd();
                }

                if (string.IsNullOrEmpty(responseString))
                    return new List<SearchResult>();

                return ParseJson(responseString, prs.engine);
            }
            return new List<SearchResult>();
        }

        public static List<SearchResult> ParseJson(string json, SearchEngine engine)
        {
            List<SearchResult> results = new List<SearchResult>();
            ResponseType responseType = engine.Type;
            
            JObject doc = JObject.Parse(json);
            JToken RootElement= doc.SelectToken(responseType.RootElementPath);
            foreach (JToken childElement in RootElement)
            {
                SearchResult result = new SearchResult
                {
                    SearchResultId = default,
                    SearchEngine = engine,
                    Title = childElement[responseType.TitleElement].ToString(),
                    Url = childElement[responseType.UrlElement].ToString(),
                    Description = childElement[responseType.DescriptionElement].ToString()
                };

                if (!string.IsNullOrEmpty(responseType.DateElement))
                {
                    string dateString = childElement[responseType.DateElement].ToString();
                    result.IndexedTime = TryParseStringDate(dateString);
                }
                else
                {
                    result.IndexedTime = null;
                }

                results.Add(result);
            }
            return results;
        }

        // <summary>
        // Parse xml from response from Yandex.Xml API and returns data as a List of SearchResult.
        // </summary>
        public static List<SearchResult> ParseXml(XDocument xmlResponse, SearchEngine engine)
        {
            List<SearchResult> results = new List<SearchResult>();

            ResponseType responseType = engine.Type;

            string[] path = responseType.RootElementPath.Split(".");

            IEnumerable<XElement> groupQuery = xmlResponse.Elements(path[0]);
            for (int i = 1; i < path.Length; i++)
            {
                groupQuery = groupQuery.Elements(path[i]);
            }

            for (int i = 0; i < groupQuery.Count(); i++)
            {
                SearchResult result = new SearchResult
                {
                    SearchResultId = default,
                    Url = GetValue(groupQuery.ElementAt(i), responseType.UrlElement),
                    Title = GetValue(groupQuery.ElementAt(i), responseType.TitleElement),
                    Description = GetValue(groupQuery.ElementAt(i), responseType.DescriptionElement),
                    SearchEngine = engine
                };
                if (result.Description == string.Empty)
                {
                    result.Description = GetValue(groupQuery.ElementAt(i), "headline");
                }

                string modtime = GetValue(groupQuery.ElementAt(i), responseType.DateElement); //example: modTime = 20160331T032014
                result.IndexedTime = TryParseStringDate(modtime);

                results.Add(result);
            }

            return results;
        }

        public static DateTime? TryParseStringDate(string stringDate)
        {
            try
            {
                string[] format = { "dd.MM.yyyy HH:mm:ss", "dd.MM.yyyy H:mm:ss", "dd-MM-yyyyTHH:mm:ss.fffZ", "dd-MM-yyyyTH:mm:ss.fffZ", "yyyyMMddTHHmmss" };
                return DateTime.ParseExact(stringDate, format, null);
            }
            catch
            {
                return null;
            }
            
        }


        /// <summary>
        /// Get string from XML element by element's name.
        /// </summary>
        public static string GetValue(XElement group, string name)
        {
            try
            {
                return group.Element("doc").Element(name).Value;
            }
            //if response hasn't this element
            catch
            {
                return string.Empty;
            }
        }

    }


}
