namespace MySearch.Models
{
    public class RequestsParameter
    {
        public int RequestsParameterId { get; set; }
        public string ParametrName { get; set; }
        public string ParametrValue { get; set; }
        public SearchEngine engine { get; set; }

    }
}
