using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using MySearch.Models;
using MySearch.Services;
using Xunit;

namespace XUnitTestProject
{
    public class Parser_UnitTests
    {

        [Theory(DisplayName = "TryParseStringDate")]
        [InlineData("20160331T032014", 2016, 3, 31, 3, 20, 14)]
        [InlineData("05.09.2019 19:57:00", 2019, 9, 5, 19, 57, 0)]
        [InlineData("05.09.2019 9:57:00", 2019, 9, 5, 9, 57, 0)]
        [InlineData("05-09-2019 9:57:00", null, null, null, null, null, null)]
        public void TryParseStringDate_Test(string stringDate, int? year, int? month, int? day, int? hour, int? minute, int? second  )
        {
            DateTime? result = ParseService.TryParseStringDate(stringDate);
            if (!year.HasValue && !month.HasValue && !day.HasValue && !hour.HasValue && !minute.HasValue && !second.HasValue)
            {
                Assert.Null(result);
            }
            else
            {
                DateTime expectedResult = new DateTime(
                    year.Value, 
                    month.Value, 
                    day.Value, 
                    hour.Value, 
                    minute.Value, 
                    second.Value
                    );
                Assert.Equal(expectedResult, result);
            }
        }

        [Theory(DisplayName = "GetValue")]
        [InlineData("XElement1.xml", "group", "title", "yandex - title")]
        [InlineData("XElement1.xml", "group", "zzzz", "")]
        [InlineData("XElement2.xml", "group", "title", "")]
        public void GetValue_Test(string fileName, string groupName, string name, string expectedValue)
        {
            string path = Environment.CurrentDirectory + "\\testData\\" + fileName;
            XmlTextReader xmlReader = new XmlTextReader(path);
            XDocument xmlResponse = XDocument.Load(xmlReader);
            XElement group = xmlResponse.Element("yandexsearch")?.Element(groupName); 
            string result = ParseService.GetValue(group, name);
            Assert.Equal(expectedValue, result);
        }

        [Theory(DisplayName = "ParseXml")]
        [InlineData(
            "yandexResponse1.xml",
            10,
            3,
            "Angular (web framework) - Wikipedia",
            "https://en.wikipedia.org/wiki/Angular_(web_framework)",
            "Angular (commonly referred to as \" Angular 2+\" or \" Angular v2 and above\") is a TypeScript-based open-source web application framework led by the Angular Team at Google and by a community of...",
            "20190528T030000"
            )]
        [InlineData(
            "yandexResponse2.xml",
            1,
            0,
            "yandex - title",
            "http://www.yandex.com/",
            "yandex - description",
            "20070510T040000"
            )]
        public void ParseXml_Test(string fileName, int count, int index, string title, string url, string description, string date )
        {
            ResponseType type = new ResponseType
            {
                ResponseTypeId = default,
                Type = "xml",
                RootElementPath = "yandexsearch.response.results.grouping.group",
                TitleElement = "title",
                DescriptionElement = "passages",
                UrlElement = "url",
                DateElement = "modtime"
            };
            SearchEngine engine = new SearchEngine
            {
                SearchEngineId = default,
                Name = "Yandex",
                BaseUrl = "https://yandex.com/search/xml?",
                IsDisable =	false,
                Type = type
            };

            SearchResult expectedResults = new SearchResult
            {
                SearchResultId = default,
                Title = title,
                Url = url,
                Description = description,
                SearchEngine = engine,
                IndexedTime = DateTime.ParseExact(date, "yyyyMMddTHHmmss", null)
            };

            Stream stream = GetFileStream(fileName);
            List<SearchResult> results = ParseService.ParseXml(stream, engine);

            Assert.Equal(count, results.Count);
            Assert.Equal(expectedResults.Title, results[index].Title);
            Assert.Equal(expectedResults.Description, results[index].Description);
            Assert.Equal(expectedResults.Url, results[index].Url);
            Assert.Equal(expectedResults.IndexedTime, results[index].IndexedTime);
            Assert.Equal(expectedResults.SearchEngine, results[index].SearchEngine);
            Assert.Equal(expectedResults.Request, results[index].Request);
            Assert.Equal(expectedResults.SearchResultId, results[index].SearchResultId);
        }


        [Theory(DisplayName = "ParseJson")]
        [InlineData(
            "googleResponse.txt",
            10,
            3,
            "items",
            "title",
            "link",
            "",
            "Angular (web framework) - Wikipedia",
            "https://en.wikipedia.org/wiki/Angular_(web_framework)",
            "Angular is a TypeScript-based open-source web application framework led by \nthe Angular Team at Google and by a community of individuals and corporations.",
            ""
            )]
        [InlineData(
            "BingResponse.txt",
            10,
            0,
            "webPages.value",
            "name",
            "url",
            "dateLastCrawled",
            "Angular",
            "https://angular.io/",
            "Angular is a platform for building mobile and desktop web applications. Join the community of millions of developers who build compelling user interfaces with Angular.",
            "05.09.2019 19:57:00"
            )]
        public void ParseJson_Test(string fileName, int count, int index, string RootElementPath, string TitleElement, string UrlElement, string DateElement, string title, string url, string description, string date)
        {
            ResponseType type = new ResponseType
            {
                ResponseTypeId = default,
                Type = "json",
                RootElementPath = RootElementPath,
                TitleElement = TitleElement,
                DescriptionElement = "snippet",
                UrlElement = UrlElement,
                DateElement = DateElement
            };
            SearchEngine engine = new SearchEngine
            {
                SearchEngineId = default,
                Name = "Google",
                BaseUrl = "https://www.googleapis.com/customsearch/v1?",
                IsDisable = false,
                Type = type
            };

            SearchResult expectedResults = new SearchResult
            {
                SearchResultId = default,
                Title = title,
                Url = url,
                Description = description,
                SearchEngine = engine
                
            };
            if (!string.IsNullOrEmpty(date))
                expectedResults.IndexedTime = DateTime.ParseExact(date, "dd.MM.yyyy HH:mm:ss", null);
            else expectedResults.IndexedTime = null;

            Stream stream = GetFileStream(fileName);
            List<SearchResult> results = ParseService.ParseJson(stream, engine);

            Assert.Equal(count, results.Count);
            Assert.Equal(expectedResults.Title, results[index].Title);
            Assert.Equal(expectedResults.Description, results[index].Description);
            Assert.Equal(expectedResults.Url, results[index].Url);
            Assert.Equal(expectedResults.IndexedTime, results[index].IndexedTime);
            Assert.Equal(expectedResults.SearchEngine, results[index].SearchEngine);
            Assert.Equal(expectedResults.Request, results[index].Request);
            Assert.Equal(expectedResults.SearchResultId, results[index].SearchResultId);
        }

        private static MemoryStream GetFileStream(string fileName)
        {
            string path = Environment.CurrentDirectory + "\\testData\\" + fileName;
            string text; // = System.IO.File.ReadAllText(path);

            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }

            return new MemoryStream(System.Text.Encoding.UTF8.GetBytes(text));
        }
    }
}
