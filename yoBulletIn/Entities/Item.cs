using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using yoBulletIn.Enums;

namespace yoBulletIn.Entities
{
    public class Item : EntityBase
    {
        public string ItemOwner { get; set; }

        [EnumDataType(typeof(ItemCategory))]
        public ItemCategory? Category {get; set;}

        //public IEnumerable<RealEstate> RealEstateItems { get; set; }
        //public IEnumerable<Clothes> ClothesItems { get; set; }
        //public IEnumerable<Car> CarsItems { get; set; }
        //public IEnumerable<Electronics> ElectronicsItems { get; set; }
    }
}
