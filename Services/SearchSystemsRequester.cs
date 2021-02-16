using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MySearch.Interfaces;
using MySearch.Models;

namespace MySearch.Services
{
    public class SearchSystemsRequester : IRequester
    {
        private IDbProvider db;

        /// <summary>
        /// Send request to each search engine, wait the fastest response and parse it
        /// </summary>
        public async Task<IEnumerable<SearchResult>> GetResultsFromFastestEngine(string searchTerm, IDbProvider db)
        {
            this.db = db;
            IQueryable<SearchEngine> searchEngines = db.GetEngines();
            List<Task<ParsedResponse>> responses = new List<Task<ParsedResponse>>();
            foreach (SearchEngine engine in searchEngines)
            {
                if (engine.IsDisable) continue;
                
                responses.Add(Task.Run(() => SendWebRequestAsync(searchTerm, engine)));
            }
            ParsedResponse fastestResponse = await Task.WhenAny(responses).Result;
            List<SearchResult> results = ParseService.ParseResponse(fastestResponse);
            return results;
        }
        
        /// <summary>
        /// Makes a request to the any API and returns data as a ParseResponseStruct with response and engine.
        /// </summary>
        private async Task<ParsedResponse> SendWebRequestAsync(string searchQuery, SearchEngine engine)
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

            ParsedResponse prs = new ParsedResponse
            {
                WebResponse = response,
                Engine = engine
            };

            return prs;
        }

        /// <summary>
        /// Build request url for this engine, create HttpWebRequest, add headers to request
        /// </summary>
        private HttpWebRequest BuildRequestToEngine(string searchQuery, SearchEngine engine)
        {
            string completeUrl = GetCompliteUrl(searchQuery, engine.Parameters, engine.BaseUrl);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(completeUrl);

            if (engine.Headers == null)
                return request;
            
            foreach (RequestHeader header in engine.Headers)
            {
                if (header.HeaderValue != string.Empty)
                {
                    request.Headers[header.HeaderName] = header.HeaderValue;
                }
            }

            return request;
        }

        public string GetCompliteUrl(string searchQuery, IEnumerable<RequestsParameter> parameters, string baseUrl)
        {
            string completeUrl = baseUrl;
            foreach (RequestsParameter parameter in parameters)
            {
                if (parameter.ParametrName == "search")
                {
                    completeUrl += parameter.ParametrValue + "=" + Uri.EscapeDataString(searchQuery);
                }
                else
                {
                    completeUrl += parameter.ParametrName + "=" + parameter.ParametrValue;
                }

                if (parameter != parameters.Last())
                {
                    completeUrl += "&";
                }
            }
            return completeUrl;
        }
        
        /// <summary>
        /// Header from response set to header for next request to this search engine
        /// </summary>
        private void SaveHeader(RequestHeader requestHeader, string responseHeader)
        {
            if (!responseHeader.Contains(requestHeader.HeaderName.Substring(0, 9)) ||
                !string.IsNullOrEmpty(requestHeader.HeaderValue))
                return;
            
            requestHeader.HeaderValue = responseHeader;
            db.SaveRequestHeaderValue(requestHeader.RequestHeaderId, responseHeader);
        }
    }
}
