using System.Collections.Generic;
using MySearch.Models;
using MySearch.Services;
using Xunit;

namespace XUnitTestProject
{
    public class SearchSystemsRequester_UnitTests
    {

        [Theory(DisplayName = "GetCompliteUrl")]
        [InlineData("https://api.cognitive.microsoft.com/bing/v7.0/search?q=angular&sortby=date",
            "angular", "search", "q", "sortby", "date",
            "https://api.cognitive.microsoft.com/bing/v7.0/search?")]
        [InlineData("https://www.googleapis.com/customsearch/v1?query=yandex&key=1234",
            "yandex", "search", "query", "key", "1234",
            "https://www.googleapis.com/customsearch/v1?")]
        public void GetCompliteUrl_Test(string expected, string searchQuery, string parameterName1, string parameterValue1, string parameterName2, string parameterValue2, string baseUrl)
        {
            List<RequestsParameter> parameters = new List<RequestsParameter>();
            parameters.Add(new RequestsParameter
            {
                ParametrName = parameterName1,
                ParametrValue = parameterValue1,
                RequestsParameterId = 1
            });
            parameters.Add(new RequestsParameter
            {
                ParametrName = parameterName2,
                ParametrValue = parameterValue2,
                RequestsParameterId = 2
            });
            SearchSystemsRequester service = new SearchSystemsRequester();

            string result = service.GetCompliteUrl(searchQuery, parameters, baseUrl);

            Assert.Equal(expected, result);
        }

        
    }
}
