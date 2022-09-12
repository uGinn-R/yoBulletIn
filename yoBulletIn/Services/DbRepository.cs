using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using yoBulletIn.Entities;

namespace yoBulletIn.Services
{
    public class DbRepository : IDbRepository
    {
        public readonly AppDbContext _context;

        public DbRepository(AppDbContext context)
        {
            _context = context;
        }


        public Item GetItemByID(Guid id)
        {
            return _context.Items.FirstOrDefault(x => x.Id == id);
        }


        public void SaveItem(Item item)
        {
            if (item.Id == default)
                _context.Entry(item).State = EntityState.Added;
            else
                _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteItem(Guid id)
        {
            _context.Items.Remove(new Item { Id = id});
            _context.SaveChangesAsync();
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public IEnumerable<Item> GetMyItems(User user)
        {
            return _context.Items.Where(x => x.ItemOwner == user.Id).ToList();
        }

        public async Task<List<Item>> FindItem(Expression<Func<Item, bool>> query)
        {
                return await _context.Items.Where(query).Select(x => x).ToListAsync();
        }
    }
}