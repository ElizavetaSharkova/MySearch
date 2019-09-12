using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySearch.Models;

namespace MySearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbEditor db;
        private readonly IService service;

        public HomeController(IDbEditor db, IService service)
        {
            this.db = db;
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchTerm)
        {
            List<SearchResult> results = (await service.GetResultsFromFastestEngine(searchTerm, db)).ToList();

            AddRequestToDb(searchTerm, results);
            ViewBag.searchString = searchTerm;
            ViewBag.results = results;
            ViewBag.isDisplayEngine = true;
            return View();
        }

        [HttpPost]
        public IActionResult History(string searchTerm)
        {
            List<SearchResult> results = db.GetResultsByRequest(searchTerm).ToList();
            ViewBag.searchString = searchTerm;
            ViewBag.results = results;
            return View();
        }

        private void AddRequestToDb(string requestString, List<SearchResult> results)
        {
            SearchRequest request = new SearchRequest
            {
                SearchRequestId = default,
                SearchString = requestString,
                SearchDate = DateTime.Now,
                SearchResults = results
            };

            db.SaveRequest(request);
        }
    }
}
