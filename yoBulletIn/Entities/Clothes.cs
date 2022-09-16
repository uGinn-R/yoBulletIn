using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using yoBulletIn.Enums;

namespace yoBulletIn.Entities
{
    public class Clothes : Item
    {
      
        [Display(Name = "Size")]
        public decimal Size { get; set; }

        [Display(Name = "Brand")]
        [MaxLength(128)]
        public string Brand { get; set; }

        public Gender? Gender { get; set; }

        public Item Item { get; set; }

        
    }
}
