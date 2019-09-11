using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySearch.Models
{
    public class ResponseType
    {
        public int ResponseTypeId { get; set; }
        public string Type { get; set; }
        public string RootElementPath { get; set; }
        public string TitleElement { get; set; }
        public string DescriptionElement { get; set; }
        public string UrlElement { get; set; }
        public string DateElement { get; set; }
        public ICollection<SearchEngine> Engines { get; set; }
    }
}
