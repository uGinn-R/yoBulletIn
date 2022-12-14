using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yoBulletIn.Entities;

namespace yoBulletIn.Services
{
    public interface IDbRepository
    {
        public IEnumerable<Item> GetAllItems();

        public IEnumerable<Item> GetMyItems(User user);

        public Task<List<Item>> FindItem(string query);

        public Item GetItemByID(Guid id);

        public void SaveItem(Item item);

        public void DeleteItem(Guid id);

    }
}
