using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yoBulletIn.Entities
{
    public class ItemImages
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(255)]
        public string ItemImage { get; set; }

        public Item Item { get;set; }

    }
}
