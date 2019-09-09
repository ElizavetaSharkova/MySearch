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

namespace MySearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbEditor db;

        private string BING_CLIENT_ID_COOKIE = string.Empty;

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
        public IActionResult Index(string searchTerm)
        {
            //List<SearchResult> results = YandexWebSearch(searchTerm);
            List<SearchResult> results = BingWebSearch(searchTerm);
            AddToDb(searchTerm, results);

            ViewBag.searchString = searchTerm;
            ViewBag.results = results;
            return View();
        }

        private void AddToDb(string requestString, List<SearchResult> results)
        {
            SearchRequest request = new SearchRequest();
            request.SearchRequestId = default;
            request.SearchString = requestString;
            request.SearchDate = DateTime.Now;
            request.SearchResults = results;

            db.SaveRequest(request);
        }

        /// <summary>
        /// Makes a request to the Yandex.Xml API and returns data as a List of SearchResult.
        /// </summary>
        private List<SearchResult> YandexWebSearch(string searchQuery)
        {
            SearchEngine engine = db.GetEngines().Where(x => x.Name == "Yandex").First();
            string urlBase = engine.BaseUrl;
            string YaAccessKey = engine.ApiKey;
 
            //Ready request string.
            string completeUrl = String.Format(urlBase, YaAccessKey, searchQuery);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(completeUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            return ParseYandexResponse(response, engine);
        }

        /// <summary>
        /// Parse xml from response from Yandex.Xml API and returns data as a List of SearchResult.
        /// </summary>
        public static List<SearchResult> ParseYandexResponse(HttpWebResponse response, SearchEngine engine)
        {
            List<SearchResult> results = new List<SearchResult>();

            XmlReader xmlReader = XmlReader.Create(response.GetResponseStream());
            XDocument xmlResponse = XDocument.Load(xmlReader);
            var groupQuery = from gr in xmlResponse.Elements().
                          Elements("response").
                          Elements("results").
                          Elements("grouping").
                          Elements("group")
                             select gr;

            for (int i = 0; i < groupQuery.Count(); i++)
            {
                SearchResult result = new SearchResult();
                result.SearchResultId = default;
                result.Url = GetValue(groupQuery.ElementAt(i), "url");
                result.Title = GetValue(groupQuery.ElementAt(i), "title");
                result.Description = GetValue(groupQuery.ElementAt(i), "passages");
                if (result.Description == string.Empty)
                {
                    result.Description = GetValue(groupQuery.ElementAt(i), "headline");
                }
                
                string modtime= GetValue(groupQuery.ElementAt(i), "modtime"); //example: modTime = 20160331T032014

                result.IndexedTime = TryParseStringDate(modtime);

                result.SearchEngine = engine;

                results.Add(result);
            }

            return results;
        }

        public static DateTime TryParseStringDate(string stringDate)
        {
            try
            {
                string[] format = { "dd.MM.yyyy HH:mm:ss", "dd.MM.yyyy H:mm:ss", "dd-MM-yyyyTHH:mm:ss.fffZ", "dd-MM-yyyyTH:mm:ss.fffZ", "yyyyMMddTHHmmss" };
                return DateTime.ParseExact(stringDate, format, null);
            }
            catch
            {
                return new DateTime();
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

        /// <summary>
        /// Makes a request to the Bing Web Search API and returns data as a List of SearchResult.
        /// </summary>
        private List<SearchResult> BingWebSearch(string searchQuery)
        {
            SearchEngine engine = db.GetEngines().Where(x => x.Name =="Bing").First();
            string uriBase = engine.BaseUrl;
            string bingAccessKey = engine.ApiKey;
            if (bingAccessKey.Length == 32)
            {
                // Construct the search request URI.
                var uriQuery = uriBase + "?q=" + Uri.EscapeDataString(searchQuery);

                // Perform request and get a response.
                WebRequest request = HttpWebRequest.Create(uriQuery);
                request.Headers["Ocp-Apim-Subscription-Key"] = bingAccessKey;
                request.Headers["X-MSEdge-ClientID"] = BING_CLIENT_ID_COOKIE;
                HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;

                BING_CLIENT_ID_COOKIE = response.Headers["X-MSEdge-ClientID"];
                List<SearchResult> results = ParseBingResponse(response, engine);

                return results;
            }
            else return new List<SearchResult>();
        }

        /// <summary>
        /// Parse json from response from Bing Search API and returns data as a List of SearchResult.
        /// </summary>
        public static List<SearchResult> ParseBingResponse(HttpWebResponse response, SearchEngine engine)
        {
            List<SearchResult> results = new List<SearchResult>();

            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();
            if (string.IsNullOrEmpty(json))
                return results;

            var doc = JObject.Parse(json);
            var webPagesDoc = doc["webPages"]["value"];
            foreach (var webPage in webPagesDoc)
            {
                SearchResult result = new SearchResult();
                result.SearchResultId = default;
                result.Title = webPage["name"].ToString();
                result.Url = webPage["url"].ToString();
                result.Description = webPage["snippet"].ToString();

                string dateLastCrawled = webPage["dateLastCrawled"].ToString(); //example: 05.09.2019 19:57:00 or 2019-09-02T22:39:00.0000000Z

                result.IndexedTime = TryParseStringDate(dateLastCrawled);
                result.SearchEngine = engine;

                results.Add(result);
            }
            return results;
        }
    }
}
