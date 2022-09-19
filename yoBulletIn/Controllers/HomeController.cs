using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
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

        [BindProperty]
        IEnumerable<ItemImages> ImagesList { get; set; }
        public HomeController(ILogger<HomeController> logger, IDbRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var LatestItems = _repo.GetAllItems().Where(s => s.Created > DateTime.Now.AddDays(-2)).ToList();

            AttachImages(LatestItems);

            return View(LatestItems);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            Expression<Func<Item, bool>> Query = x => x.Description.Contains(query) || x.Title.Contains(query);

            var result = await _repo.FindItem(Query);
            if (result.Count < 1)
            {
                return View("Index");
            }
            AttachImages(result);
            ViewData["Title"] = query;
            return View("_SearchPartial", result);
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

        
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) }
            );

            return LocalRedirect(returnUrl);
        }

        public void AttachImages(List<Item> itemsList)
        {
            foreach (var item in itemsList)
            {
                ImagesList = _repo.GetAllItemImages(item.Id);
                item.ImgPath = ImagesList.ToList();
            }
        }
    }
}
