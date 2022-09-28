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

        public IActionResult Index()
        {
            var myAds = _repo.GetMyItems(_UserManager.GetUserId(User));
            var thisUser = _UserManager.GetUserAsync(User);
            return View(thisUser.Result);
        }

        public async Task<IActionResult> UploadAvatar(IFormFile Image)
        {
            if (Image != null)
            {
                var response = ImageUploader.UploadAvatarImage(Image);
                    if (response.StatusCode == 200) // OK
                    {
                        var currentUser = await _UserManager.GetUserAsync(User);
                        currentUser.AvatarImg = response.URL;
                        await _UserManager.UpdateAsync(currentUser);
                        return View();
                    }
            }
            return RedirectToPage("UserProfile");
        }
    }
}
