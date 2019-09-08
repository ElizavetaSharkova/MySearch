using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySearch.Models
{
    public class SearchEngine
    {
        public int SearchEngineId { get; set; }
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
    }
}
