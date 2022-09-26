using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace yoBulletIn.Entities
{
    public class PM
    {
        public PM() => CreationTime = DateTime.UtcNow;

        [Key]
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string MessageAuthor { get; set; }
        public Guid ItemId { get; set; }

        public DateTime CreationTime { get; set; }

        [NotMapped]
        public virtual List<Item> Item { get; set; }
        public User User { get; set; }
    }
}
