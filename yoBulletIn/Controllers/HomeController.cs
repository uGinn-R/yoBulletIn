using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using yoBulletIn.Entities;
using yoBulletIn.Models;
using yoBulletIn.Services;

namespace yoBulletIn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbRepository _repo;

        public HomeController(ILogger<HomeController> logger, IDbRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {  
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            Expression<Func<Item, bool>> Query = x => x.Description.Contains(query) || x.Title.Contains(query);
            return View("_SearchPartial" ,await _repo.FindItem(Query));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
