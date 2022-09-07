using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace yoBulletIn.Entities
{
    public class Clothes : Item
    {
      
        [Display(Name = "Size")]
        [DataType(DataType.Custom)]
        public decimal Size { get; set; }

        [Display(Name = "Brand")]
        public string Brand { get; set; }

        public Gender? gender { get; set; }

        public Item Item { get; set; }

        
    }
}
