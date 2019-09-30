using MySearch.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MySearch.Models
{
    public interface IRequester
    {
        Task<IEnumerable<SearchResult>> GetResultsFromFastestEngine(string searchTerm, IDbEditor db);

        HttpWebRequest BuildRequestToEngine(string searchQuery, SearchEngine engine);
        Task<ParseResponseStruct> SendWebRequestAsync(string searchQuery, SearchEngine engine);

        void SaveHeader(RequestHeader requestHeader, string responseHeader);
        string GetCompliteUrl(string searchQuery, IEnumerable<RequestsParameter> parameters, string baseUrl);
    }
}
