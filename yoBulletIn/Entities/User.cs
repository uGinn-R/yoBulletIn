using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yoBulletIn.Entities
{
    public class User : IdentityUser
    {
        public User() => Registered = Registered.Equals(DateTime.MinValue) ? DateTime.UtcNow : Registered;

        [DataType(DataType.DateTime)]
        public DateTime Registered { get; set; }
        public string AvatarImg
        {
            get
            {
                return _AvatarImagePath ?? "/images/no_image.png";
            }
            set
            {
                _AvatarImagePath = value;
            }
        }
        private string _AvatarImagePath;

        public IEnumerable<PM> Messages { get; set; }
        public IEnumerable<Item> UserItems { get; set; }
    }
}