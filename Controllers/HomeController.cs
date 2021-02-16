using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySearch.Interfaces;
using MySearch.Models;

namespace MySearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbProvider db;
        private readonly IRequester requester;

        public HomeController(IDbProvider db, IRequester requester)
        {
            this.db = db;
            this.requester = requester;
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
            SearchRequest request = CreateRequest(searchTerm);
            request.SearchResults = (await requester.GetResultsFromFastestEngine(searchTerm, db)).ToList();

            db.SaveRequest(request);

            ViewBag.isDisplayEngine = true;
            return View(request);
        }

        [HttpPost]
        public IActionResult History(string searchTerm)
        {
            SearchRequest request = CreateRequest(searchTerm);
            request.SearchResults = db.GetResultsByRequest(searchTerm).ToList();

            return View(request);
        }

        private SearchRequest CreateRequest(string requestString)
        {
            SearchRequest request = new SearchRequest
            {
                SearchRequestId = default,
                SearchString = requestString,
                SearchDate = DateTime.Now
            };

            return request;
        }
    }
}
