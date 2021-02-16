namespace MySearch.Models
{
    public class RequestHeader
    {
        public int RequestHeaderId { get; set; }
        public string HeaderName { get; set; }
        public string HeaderValue { get; set; }
        public SearchEngine engine { get; set; }
    }
}
