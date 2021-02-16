using System.Linq;
using MySearch.Models;

namespace MySearch.Interfaces
{
    public interface IDbProvider
    {
        IQueryable<SearchEngine> GetEngines();
        IQueryable<SearchResult> GetResultsByRequest(string requestStr);
        void SaveRequest(SearchRequest request);
        bool IsExistResult(SearchResult result);
        void SaveRequestHeaderValue(int id, string value);
    }
}
