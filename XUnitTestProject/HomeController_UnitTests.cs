using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySearch.Controllers;
using MySearch.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using Xunit;

namespace XUnitTestProject
{
    public class HomeController_UnitTests
    {

        [Fact(DisplayName = "Index")]
        public void Index_Get_Test()
        {
            FakeDbEditor dbEditor = new FakeDbEditor();
            HttpService service = new HttpService();
            HomeController controller = new HomeController(dbEditor, service);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
            Assert.Null(controller.ViewBag.results);
            Assert.Null(controller.ViewBag.searchString);
            Assert.Null(controller.ViewBag.isDisplayEngine);

        }

        [Fact(DisplayName = "History")]
        public void History_Get_Test()
        {
            FakeDbEditor dbEditor = new FakeDbEditor();
            HttpService service = new HttpService();
            HomeController controller = new HomeController(dbEditor, service);

            var result = controller.History();

            Assert.IsType<ViewResult>(result);
            Assert.Null(controller.ViewBag.results);
            Assert.Null(controller.ViewBag.searchString);
            Assert.Null(controller.ViewBag.isDisplayEngine);
        }


        [Theory(DisplayName = "History_Post")]
        [InlineData("asp.net")]
        public void History_Post_Test(string searchString)
        {
            FakeDbEditor dbEditor = new FakeDbEditor();
            dbEditor.searchResults = new List<SearchResult>();
            dbEditor.searchRequests = new List<SearchRequest>();
            HttpService service = new HttpService();
            HomeController controller = new HomeController(dbEditor, service);
            
            SearchResult searchResult = new SearchResult
            {
                SearchResultId = 1,
                Title = "Test title",
                Url = "test url",
                Description = "test description",
                IndexedTime = DateTime.Now
            };
            List<SearchResult> req1 = new List<SearchResult>();
            req1.Add(searchResult);
            SearchRequest searchRequest = new SearchRequest
            {
                SearchRequestId = 1,
                SearchString = searchString,
                SearchDate = DateTime.Now,
                SearchResults = req1
            };
            List<SearchRequest> req = (List<SearchRequest>)dbEditor.searchRequests;
            req.Add(searchRequest);
            dbEditor.searchRequests = req;
            List<SearchResult> res = (List<SearchResult>)dbEditor.searchResults;
            res.Add(searchResult);
            dbEditor.searchResults = res;

            var result = controller.History(searchString);

            Assert.IsType<ViewResult>(result);
            Assert.Equal(searchString, controller.ViewBag.searchString);
            Assert.Null(controller.ViewBag.isDisplayEngine);
            Assert.Equal(searchResult.Title, controller.ViewBag.results[0].Title);
            Assert.Equal(searchResult.Description, controller.ViewBag.results[0].Description);
            Assert.Equal(searchResult.Url, controller.ViewBag.results[0].Url);
            Assert.Equal(searchResult.IndexedTime, controller.ViewBag.results[0].IndexedTime);
            Assert.Equal(searchResult.SearchEngine, controller.ViewBag.results[0].SearchEngine);
            Assert.Equal(searchResult.Request, controller.ViewBag.results[0].Request);
            Assert.Equal(searchResult.SearchResultId, controller.ViewBag.results[0].SearchResultId);
        }

    }
}
