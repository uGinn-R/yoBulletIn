using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yoBulletIn.Entities
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Created = DateTime.UtcNow;
        }

        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name field can't be empty")]
        [Display(Name = "Title (Name)")]
        [MaxLength(128)]
        public virtual string Title { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public virtual string Description { get; set; } = string.Empty;

        [Display(Name = "Images")]
        public virtual List<ItemImages> ImgPath { get; set; }

        public virtual List<PM> ItemMesages { get; set; }

        [Required(ErrorMessage = "Price is incorrect!")]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public virtual decimal Price { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }
    }
}
