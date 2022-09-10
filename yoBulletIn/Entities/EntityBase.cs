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
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name field can't be empty")]
        [Display(Name = "Title (Name)")]
        public virtual string Title { get; set; }

        [Display(Name = "Description")]
        public virtual string Description { get; set; }

        [Display(Name = "Image")]
        public virtual string ImgPath { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }
    }
}
