using MySearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MySearch.Controllers
{
    public class HttpService
    {
        private DbEditor db;
        public HttpService()
        {
        }

        public async Task<List<SearchResult>> GetResultsFromFastestEngine(string searchTerm, DbEditor db)
        {
            this.db = db;
            IQueryable<SearchEngine> searchEngines = db.GetEngines();
            List<Task<ParseResponseStruct>> responses = new List<Task<ParseResponseStruct>>();
            foreach (SearchEngine engine in searchEngines)
            {
                if (!engine.IsDisable)
                {
                    responses.Add(Task.Run(() => SendWebRequestAsync(searchTerm, engine)));
                }
            }
            ParseResponseStruct fastestResponse = await Task.WhenAny(responses).Result;
            List<SearchResult> results = Parser.ParseResponse(fastestResponse);
            return results;
        }

        public static HttpWebRequest BuildRequestToEngine(string searchQuery, SearchEngine engine)
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
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            foreach (string responseHeader in response.Headers)
            {
                foreach (RequestHeader requestHeader in engine.Headers)
                {
                    SaveHeader(requestHeader, responseHeader);
                }
            }

            ParseResponseStruct prs = new ParseResponseStruct
            {
                webResponse = response,
                engine = engine
            };

            return prs;
        }

        public void SaveHeader(RequestHeader requestHeader, string responseHeader)
        {
            if (responseHeader.Contains(requestHeader.HeaderName.Substring(0, 9)) &&
                        string.IsNullOrEmpty(requestHeader.HeaderValue))
            {
                requestHeader.HeaderValue = responseHeader;
                db.SaveRequestHeaderValue(requestHeader.RequestHeaderId, responseHeader);
            }
        }


    }
}
