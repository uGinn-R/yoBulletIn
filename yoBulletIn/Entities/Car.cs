using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using yoBulletIn.Enums;

namespace yoBulletIn.Entities
{
    public class Car : Item
    {
        
        [Display(Name = "Model")]
        public string Model { get; set; }
        private DateTime? year { get; set; } = null;
        [Display(Name = "Year")]
        public DateTime Year { get { return year?? DateTime.Now; } set { this.year = value; }  }
        [Display(Name = "Mileage, km")]
        public int Mileage { get; set; }
        [Display(Name = "Mark")]
        public CarMarks Mark { get; set; }

        public Item Item { get; set; }
    }
}
