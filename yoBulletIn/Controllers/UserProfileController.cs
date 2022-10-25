using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yoBulletIn.Entities;
using yoBulletIn.Services;

namespace yoBulletIn.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IDbRepository _repo;
        readonly UserManager<User> _UserManager;

        public UserProfileController(IDbRepository repo, UserManager<User> UserManager)
        {
            _repo = repo;
            _UserManager = UserManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await FillUserModelAsync());
        }

        public IActionResult Delete(Guid id)
        {
            _repo.DeleteItem(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UploadAvatar(IFormFile Image)
        {
            var currentUser = await _UserManager.GetUserAsync(User);

            if (Image != null)
            {
                var response = ImageUploader.UploadAvatarImage(Image);
                    if (response.StatusCode == 200) // OK
                    {
                        currentUser.AvatarImg = response.URL;
                        await _UserManager.UpdateAsync(currentUser);

                        var myAds = _repo.GetMyItems(_UserManager.GetUserId(User));
                        currentUser.UserItems = myAds;

                    return View("Index", currentUser);
                }
            }
            return View("Index", currentUser);
        }

        public async Task<IActionResult> ItemsPartial()
        {
            return PartialView("_ItemsPartial", await FillUserModelAsync());
        }

        public async Task<IActionResult> MessagesPartial()
        {
            return PartialView("_MessagesPartial", await FillUserModelAsync());
        }

        private async Task<User> FillUserModelAsync()
        {
            var ThisUser = await _UserManager.GetUserAsync(User);
            var MyAds = _repo.GetMyItems(_UserManager.GetUserId(User));
            ThisUser.UserItems = MyAds;

            return ThisUser;
        }
    }
}
