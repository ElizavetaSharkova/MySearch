using System;
using System.Collections.Generic;

namespace MySearch.Models
{
    public class SearchRequest
    {
        public int SearchRequestId { get; set; }
        public string SearchString { get; set; }
        public DateTime SearchDate { get; set; }

        public ICollection<SearchResult> SearchResults { get; set; }
    }
}
