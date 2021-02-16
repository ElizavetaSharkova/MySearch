using System.Collections.Generic;
using System.Threading.Tasks;
using MySearch.Models;

namespace MySearch.Interfaces
{
    public interface IRequester
    {
        Task<IEnumerable<SearchResult>> GetResultsFromFastestEngine(string searchTerm, IDbProvider db);
    }
}
