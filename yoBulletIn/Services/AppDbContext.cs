using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yoBulletIn.Entities;

namespace yoBulletIn
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<Electronics> Electronics { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<ItemImages> ItemImages { get; set; }
    }
}
