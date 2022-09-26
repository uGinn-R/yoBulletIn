using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yoBulletIn.Entities;
using yoBulletIn.Services;

namespace yoBulletIn.Controllers
{
    public class ItemCartController : Controller
    {
        private readonly IDbRepository _repo;
        readonly UserManager<User> _UserManager;

        public ItemCartController(IDbRepository repo, UserManager<User> UserManager)
        {
            _repo = repo;
            _UserManager = UserManager;
        }
        public IActionResult Index(Guid ID)
        {
            var CurrentItem = _repo.GetItemByID(ID);

            return View(CurrentItem);
        }

        [HttpPost]
        public void AddComment(string user ,string message, Guid ItemId)
        {
            PM pm = new PM()
            {
                Message = message,
                ItemId = ItemId,
                MessageAuthor = user
            };
            
            _repo.SavePM(pm);
        }
    }
}
