using System.Collections.Generic;
using System.Linq;
using MySearch.Interfaces;
using MySearch.Models;

namespace MySearch.DbProviders
{
    public class FakeDbProvider: IDbProvider
    {
        public IEnumerable<SearchResult> searchResults;
        public IEnumerable<SearchRequest> searchRequests;
        public IEnumerable<SearchEngine> searchEngines;
        public IEnumerable<RequestHeader> requestHeaders;
        public IEnumerable<RequestsParameter> requestsParameters;
        public IEnumerable<ResponseType> responseTypes;

        public FakeDbProvider() { }
        public FakeDbProvider(IEnumerable<SearchResult> searchResults, 
            IEnumerable<SearchRequest> searchRequests,
            IEnumerable<SearchEngine> searchEngines,
            IEnumerable<RequestHeader> requestHeaders,
            IEnumerable<RequestsParameter> requestsParameters,
            IEnumerable<ResponseType> responseTypes)
        {
            this.searchResults = searchResults;
            this.searchRequests = searchRequests;
            this.searchEngines = searchEngines;
            this.requestHeaders = requestHeaders;
            this.requestsParameters = requestsParameters;
            this.responseTypes = responseTypes;
        }

        //выбрать все записи из таблицы SearchEngine
        public IQueryable<SearchEngine> GetEngines()
        {
            return searchEngines.AsQueryable();
        }

        //найти все результаты по строке запроса
        public IQueryable<SearchResult> GetResultsByRequest(string requestStr)
        {
            foreach (SearchRequest req in searchRequests)
            {
                if (req.SearchString == requestStr)
                {
                    return req.SearchResults.AsQueryable();
                }
            }
            return new List<SearchResult>().AsQueryable();
        }

        //сохранить новый request вместе со всеми results в БД
        public void SaveRequest(SearchRequest request)
        {
            if (request.SearchRequestId == default)
            {
                if (request.SearchResults != null)
                {
                    List<SearchResult> res = (List<SearchResult>)searchResults;
                    foreach (SearchResult result in request.SearchResults)
                    {
                        if (result.SearchResultId == default && !IsExistResult(result))
                        {
                            res.Add(result);
                        }
                    }
                    searchResults = res;
                }
                List<SearchRequest> req = (List<SearchRequest>)searchRequests;
                req.Add(request);
                searchRequests = req;
            }
        }

        public bool IsExistResult(SearchResult result)
        {
            foreach (SearchResult res in searchResults)
            {
                if (res.Url == result.Url && res.Request.SearchString == result.Request.SearchString)
                {
                    return true;
                }
            }

            return false;
        }

        public void SaveRequestHeaderValue(int id, string value)
        {
            foreach (RequestHeader header in requestHeaders)
            {
                if (header.RequestHeaderId == id)
                {
                    header.HeaderValue = value;
                }
            }
        }
    }
}
