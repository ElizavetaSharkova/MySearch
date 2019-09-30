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
            SearchSystemsRequester service = new SearchSystemsRequester();
            HomeController controller = new HomeController(dbEditor, service);

            var result = controller.Index();

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Null(controller.ViewBag.isDisplayEngine);

        }

        [Fact(DisplayName = "History")]
        public void History_Get_Test()
        {
            FakeDbEditor dbEditor = new FakeDbEditor();
            SearchSystemsRequester service = new SearchSystemsRequester();
            HomeController controller = new HomeController(dbEditor, service);

            var result = controller.History();
            
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("History", redirectToActionResult.ActionName);
            Assert.Null(controller.ViewBag.isDisplayEngine);
        }


        [Theory(DisplayName = "History_Post")]
        [InlineData("asp.net")]
        public void History_Post_Test(string searchString)
        {
            FakeDbEditor dbEditor = new FakeDbEditor();
            dbEditor.searchResults = new List<SearchResult>();
            dbEditor.searchRequests = new List<SearchRequest>();
            SearchSystemsRequester service = new SearchSystemsRequester();
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
            Assert.Null(controller.ViewBag.isDisplayEngine);

            Assert.Equal( typeof(SearchRequest), controller.ViewData.Model.GetType());
            SearchRequest model = (SearchRequest)controller.ViewData.Model;

            Assert.True(model.SearchResults.Contains(searchResult));
        }

    }
}
