using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yoBulletIn.Entities;
using yoBulletIn.Services;
using yoBulletIn.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace yoBulletIn.Controllers
{
    public class ItemController : Controller
    {
        private readonly IDbRepository _repo;
        UserManager<User> _UserManager;

        public ItemController(IDbRepository repo, UserManager<User> UserManager)
        {
            _repo = repo;
            _UserManager = UserManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateItem()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Item item)
        {
            return item.Category switch
            {
                ItemCategory.RealEstate => View("CreateRealEstatePartial", new RealEstate() { Category = ItemCategory.RealEstate }),
                ItemCategory.Cars => View("CreateCarsPartial", new Car() { Category = ItemCategory.Cars }),
                ItemCategory.Electronics => View("CreateElectronicsPartial", new Electronics() { Category = ItemCategory.Electronics }),
                ItemCategory.Clothes => View("CreateClothesPartial", new Clothes() { Category = ItemCategory.Clothes }),
                ItemCategory.Other => View("CreateOtherPartial", new Item() { Category = ItemCategory.Other }),
                _ => View(),
            };
        }

        [HttpPost]
        public IActionResult SaveRealEstate(RealEstate RE)
        {
            _repo.SaveItem(RE);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SaveClothes(Clothes clothes)
        {
            _repo.SaveItem(clothes);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SaveCars(Car car, IFormFile Image)
        {
            car.ItemOwner = _UserManager.GetUserId(User);
            if (Image != null)
            {
                var response = ImageUploader.UploadImage(Image);
                if (response.StatusCode == 200) // OK
                {
                    car.ImgPath = response.URL;
                }
            }
            _repo.SaveItem(car);
            return RedirectToAction("Index", "Home");
        }
    }
}
