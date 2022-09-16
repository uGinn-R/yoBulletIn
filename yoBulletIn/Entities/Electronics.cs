using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace yoBulletIn.Entities
{
    public class Electronics : Item
    {
        [Display(Name = "Brand")]
        [MaxLength(128)]
        public string Brand { get; set; }
        [Display(Name = "Model")]
        [MaxLength(128)]
        public string Model { get; set; }
        [Display(Name = "Portable device")]
        public bool Portable { get; set; }

        public Item Item { get; set; }
    }
}
