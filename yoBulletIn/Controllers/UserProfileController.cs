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
        public User thisUser { get; set; }
        public IEnumerable<Item> myAds { get; set; }

        public UserProfileController(IDbRepository repo, UserManager<User> UserManager)
        {
            _repo = repo;
            _UserManager = UserManager;
        }

        public IActionResult Index()
        {
            return View(FillUserModel().Result);
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

        public IActionResult ItemsPartial()
        {
            return PartialView("_ItemsPartial", FillUserModel().Result);
        }

        public IActionResult MessagesPartial()
        {
            return PartialView("_MessagesPartial", FillUserModel().Result);
        }

        public async Task<User> FillUserModel()
        {
            thisUser = await _UserManager.GetUserAsync(User);
            myAds = _repo.GetMyItems(_UserManager.GetUserId(User));
            thisUser.UserItems = myAds;

            return thisUser;
        }
    }
}
