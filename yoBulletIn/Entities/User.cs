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
        public User() => Registered = DateTime.UtcNow;

        [DataType(DataType.DateTime)]
        public DateTime Registered { get; set; }

        public IEnumerable<Item> UserItems { get; set; }
    }
}
