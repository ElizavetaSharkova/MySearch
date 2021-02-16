using System;

namespace MySearch.Models
{
    public class SearchResult
    {
        public int SearchResultId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime? IndexedTime { get; set; }
        public SearchRequest Request { get; set; }
        public SearchEngine SearchEngine { get; set; }
    }
}
