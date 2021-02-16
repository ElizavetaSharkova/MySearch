using Microsoft.AspNetCore.Mvc;
using MySearch.Controllers;
using System;
using System.Collections.Generic;
using MySearch.DbProviders;
using MySearch.Models;
using MySearch.Services;
using Xunit;

namespace XUnitTestProject
{
    public class HomeController_UnitTests
    {

        [Fact(DisplayName = "Index")]
        public void Index_Get_Test()
        {
            FakeDbProvider dbProvider = new FakeDbProvider();
            SearchSystemsRequester service = new SearchSystemsRequester();
            HomeController controller = new HomeController(dbProvider, service);

            var result = controller.Index();

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Null(controller.ViewBag.isDisplayEngine);

        }

        [Fact(DisplayName = "History")]
        public void History_Get_Test()
        {
            FakeDbProvider dbProvider = new FakeDbProvider();
            SearchSystemsRequester service = new SearchSystemsRequester();
            HomeController controller = new HomeController(dbProvider, service);

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
            FakeDbProvider dbProvider = new FakeDbProvider();
            dbProvider.searchResults = new List<SearchResult>();
            dbProvider.searchRequests = new List<SearchRequest>();
            SearchSystemsRequester service = new SearchSystemsRequester();
            HomeController controller = new HomeController(dbProvider, service);

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
            List<SearchRequest> req = (List<SearchRequest>)dbProvider.searchRequests;
            req.Add(searchRequest);
            dbProvider.searchRequests = req;
            List<SearchResult> res = (List<SearchResult>)dbProvider.searchResults;
            res.Add(searchResult);
            dbProvider.searchResults = res;

            var result = controller.History(searchString);

            Assert.IsType<ViewResult>(result);
            Assert.Null(controller.ViewBag.isDisplayEngine);

            Assert.Equal( typeof(SearchRequest), controller.ViewData.Model.GetType());
            SearchRequest model = (SearchRequest)controller.ViewData.Model;

            Assert.True(model.SearchResults.Contains(searchResult));
        }

    }
}
