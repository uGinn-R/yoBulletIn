using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using yoBulletIn.Entities;

namespace yoBulletIn.Services
{
    public interface IDbRepository
    {
        public IEnumerable<Item> GetAllItems();

        public IEnumerable<Item> GetPaginatedItems(int Count, int Page = 1);

        public IEnumerable<Item> GetMyItems(User user);

        public IEnumerable<ItemImages> GetAllItemImages(Guid Id);

        public Task<List<Item>> FindItem(Expression<Func<Item, bool>> query);

        public Item GetItemByID(Guid id);

        public void SaveItem(Item item);

        public void SaveItemImage(ItemImages itemImage);

        public void DeleteItem(Guid id);

    }
}
