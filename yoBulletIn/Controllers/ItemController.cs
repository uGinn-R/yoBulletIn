using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yoBulletIn.Entities;
using yoBulletIn.Services;

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
            switch (item.Category)
            {
                case ItemCategory.RealEstate:
                    return View("CreateRealEstatePartial", new RealEstate() { Category = ItemCategory.RealEstate });

                case ItemCategory.Cars:
                    return View("CreateCarsPartial", new Car() { Category = ItemCategory.Cars });

                case ItemCategory.Electronics:
                    return View("CreateElectronicsPartial", new Electronics() { Category = ItemCategory.Electronics });

                case ItemCategory.Clothes:
                    return View("CreateClothesPartial", new Clothes() { Category = ItemCategory.Clothes});

                case ItemCategory.Other:
                    return View("CreateOtherPartial", new Item() { Category = ItemCategory.Other });

                default:
                    return View();
            }
            
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
    }
}
