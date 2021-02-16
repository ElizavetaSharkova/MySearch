using System.Collections.Generic;

namespace MySearch.Models
{
    public class SearchEngine
    {
        public int SearchEngineId { get; set; }
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public bool IsDisable { get; set; }
        public ICollection<RequestsParameter> Parameters { get; set; }
        public ICollection<RequestHeader> Headers { get; set; }
        public ResponseType Type { get; set; }
    }
}
