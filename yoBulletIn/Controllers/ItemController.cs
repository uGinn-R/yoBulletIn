using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yoBulletIn.Entities;
using yoBulletIn.Services;
using yoBulletIn.Enums;

namespace yoBulletIn.Controllers
{
    public class ItemController : Controller
    {
        private readonly IDbRepository _repo;

        public ItemController(IDbRepository repo)
        {
            _repo = repo;
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
        public IActionResult SaveCars(Car cars)
        {
            _repo.SaveItem(cars);
            return RedirectToAction("Index", "Home");
        }
    }
}
