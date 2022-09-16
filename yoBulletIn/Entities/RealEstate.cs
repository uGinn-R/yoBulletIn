using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace yoBulletIn.Entities
{
    public class RealEstate : Item
    {
        [Display(Name = "Area, M2")]
        
        public decimal Area { get; set; }
        [Display(Name = "Number of Rooms")]
        public int NumberOfRooms { get; set; }
        [Display(Name = "Floor")]
        public int Floor { get; set; }

        public Item Item { get; set; }
    }
}
