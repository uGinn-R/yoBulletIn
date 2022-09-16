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
        readonly UserManager<User> _UserManager;

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
                ItemCategory.RealEstate => View("CreateRealEstatePartial", new RealEstate() { Category = ItemCategory.RealEstate, ItemOwner = _UserManager.GetUserId(User) }),
                ItemCategory.Cars => View("CreateCarsPartial", new Car() { Category = ItemCategory.Cars, ItemOwner = _UserManager.GetUserId(User) }),
                ItemCategory.Electronics => View("CreateElectronicsPartial", new Electronics() { Category = ItemCategory.Electronics, ItemOwner = _UserManager.GetUserId(User) }),
                ItemCategory.Clothes => View("CreateClothesPartial", new Clothes() { Category = ItemCategory.Clothes, ItemOwner = _UserManager.GetUserId(User) }),
                ItemCategory.Other => View("CreateOtherPartial", new Item() { Category = ItemCategory.Other, ItemOwner = _UserManager.GetUserId(User) }),
                _ => View(),
            };
        }

        [HttpPost]
        public IActionResult SaveRealEstate(RealEstate realEstate, List<IFormFile> Image)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateRealEstatePartial", realEstate);
            }

            if (Image.Count > 0)
            {
                var responses = ImageUploader.UploadImage(Image);
                foreach (var response in responses)
                {
                    if (response.StatusCode == 200) // OK
                    {
                        _repo.SaveItemImage(new ItemImages { ItemImage = response.URL, Item = realEstate });
                    }
                }
            }

            _repo.SaveItem(realEstate);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SaveClothes(Clothes clothes, List<IFormFile> Image)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateClothesPartial", clothes);
            }

            if (Image.Count > 0)
            {
                var responses = ImageUploader.UploadImage(Image);
                foreach (var response in responses)
                {
                    if (response.StatusCode == 200) // OK
                    {
                        _repo.SaveItemImage(new ItemImages { ItemImage = response.URL, Item = clothes });
                    }
                }
            }

            _repo.SaveItem(clothes);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SaveElectronics(Electronics electronics, List<IFormFile> Image)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateElectronicsPartial", electronics);
            }

            if (Image.Count > 0)
            {
                var responses = ImageUploader.UploadImage(Image);
                foreach (var response in responses)
                {
                    if (response.StatusCode == 200) // OK
                    {
                        _repo.SaveItemImage(new ItemImages { ItemImage = response.URL, Item = electronics });
                    }
                }
            }

            _repo.SaveItem(electronics);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SaveCars(Car car, List<IFormFile> Image)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCarsPartial",car);
            }

            //car.ItemOwner = _UserManager.GetUserId(User);
            if (Image.Count > 0)
            {
                var responses = ImageUploader.UploadImage(Image);
                foreach (var response in responses)
                {
                    if (response.StatusCode == 200) // OK
                    {
                        _repo.SaveItemImage(new ItemImages { ItemImage = response.URL, Item = car });
                    }
                }
            }
            
            _repo.SaveItem(car);
            
            return RedirectToAction("Index", "Home");
        }

    }
}
