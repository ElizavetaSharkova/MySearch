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

namespace MySearch.Controllers
{
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
        public IActionResult Index(string searchTerm)
        {
            //string results;
            //SearchResult result = BingWebSearch(searchTerm);
            //if (result.jsonResult != null)
            //{
            //    results = JsonPrettyPrint(result.jsonResult);
            //}
            //else
            //{
            //    results = "Invalid Bing Search API subscription key!";
            //}

            //AddToDb(searchTerm);

            //ViewBag.results = results;
            return View();
        }

        private void AddToDb(string requestString)
        {
            SearchRequest request = new SearchRequest();
            request.SearchRequestId = default;
            request.SearchString = requestString;
            request.SearchDate = DateTime.Now;

            db.SaveRequest(request);
        }

        /// <summary>
        /// Makes a request to the Bing Web Search API and returns data as a SearchResult.
        /// </summary>
        private SearchResult BingWebSearch(string searchQuery)
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
                HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
                string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

                // Create a result object.
                var searchResult = new SearchResult()
                {
                    jsonResult = json,
                    relevantHeaders = new Dictionary<String, String>()
                };

                // Extract Bing HTTP headers.
                foreach (String header in response.Headers)
                {
                    if (header.StartsWith("BingAPIs-") || header.StartsWith("X-MSEdge-"))
                        searchResult.relevantHeaders[header] = response.Headers[header];
                }
                return searchResult;
            }
            else return new SearchResult();
        }

        /// <summary>
        /// Formats the JSON string by adding line breaks and indents.
        /// </summary>
        /// <param name="json">The raw JSON string.</param>
        /// <returns>The formatted JSON string.</returns>
        private string JsonPrettyPrint(string json)
        {
            if (string.IsNullOrEmpty(json))
                return string.Empty;

            json = json.Replace(Environment.NewLine, "").Replace("\t", "");

            StringBuilder sb = new StringBuilder();
            bool quote = false;
            bool ignore = false;
            char last = ' ';
            int offset = 0;
            int indentLength = 2;

            foreach (char ch in json)
            {
                switch (ch)
                {
                    case '"':
                        if (!ignore) quote = !quote;
                        break;
                    case '\\':
                        if (quote && last != '\\') ignore = true;
                        break;
                }

                if (quote)
                {
                    sb.Append(ch);
                    if (last == '\\' && ignore) ignore = false;
                }
                else
                {
                    switch (ch)
                    {
                        case '{':
                        case '[':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', ++offset * indentLength));
                            break;
                        case ']':
                        case '}':
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', --offset * indentLength));
                            sb.Append(ch);
                            break;
                        case ',':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', offset * indentLength));
                            break;
                        case ':':
                            sb.Append(ch);
                            sb.Append(' ');
                            break;
                        default:
                            if (quote || ch != ' ') sb.Append(ch);
                            break;
                    }
                }
                last = ch;
            }
            return sb.ToString().Trim();
        }
    }

    public struct SearchResult
    {
        public String jsonResult;
        public Dictionary<String, String> relevantHeaders;
    }
}
