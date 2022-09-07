using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace yoBulletIn.Entities
{
    public class Car : Item
    {
        [Display(Name = "Mark")]
        public string Mark { get; set; }
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Display(Name = "Year")]
        public DateTime Year { get; set; }
        [Display(Name = "Mileage, km")]
        public int Mileage { get; set; }

        public Item Item { get; set; }
    }
}
