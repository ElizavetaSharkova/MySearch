using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySearch.Models
{
    public interface IDbEditor
    {
        IQueryable<SearchEngine> GetEngines();
        IQueryable<SearchResult> GetResultsByRequest(string requestStr);
        void SaveRequest(SearchRequest request);
        bool IsExistResult(SearchResult result);
        void SaveRequestHeaderValue(int id, string value);
    }
}
