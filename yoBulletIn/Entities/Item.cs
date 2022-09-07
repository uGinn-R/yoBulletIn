using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace yoBulletIn.Entities
{
    public class Item : EntityBase
    {
        public User ItemOwner { get; set; }

        [EnumDataType(typeof(ItemCategory))]
        public ItemCategory? Category {get; set;}
        
        public IEnumerable<RealEstate> RealEstateItems { get; set; }
        public IEnumerable<Clothes> ClothesItems { get; set; }
    }
}
