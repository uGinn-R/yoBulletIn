using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace yoBulletIn.Entities
{
        public enum ItemCategory
        {
            [Display(Name = "Cars / Vehicles")]
            Cars,
            [Display(Name = "Consumer Electronics")]
            Electronics,
            [Display(Name = "Real Estate")]
            RealEstate,
            [Display(Name = "Clothes, Fashion")]
            Clothes,
            [Display(Name = "Other")]
            Other
        }
}
