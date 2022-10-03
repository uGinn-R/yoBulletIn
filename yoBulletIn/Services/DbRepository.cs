﻿using Microsoft.AspNetCore.Identity;
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
        IEnumerable<ItemImages> ImagesList { get; set; }
        private readonly UserManager<User> _userManager;

        
        public DbRepository(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Item GetItemByID(Guid id)
        {   var model = _context.Items.FirstOrDefault(x => x.Id == id);
            ImagesList = GetAllItemImages(id);
            model.ImgPath = ImagesList.ToList();
            return model;
        }


        public void SaveItem(Item item)
        {
            if (item.Id == default)
                _context.Entry(item).State = EntityState.Added;
            else
                _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void SaveItemImage(ItemImages itemImage)
        {
            if (itemImage.Id == default)
                _context.Entry(itemImage).State = EntityState.Added;
            else
                _context.Entry(itemImage).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void SavePM(PM message)
        {
            if (message.Id == default)
                _context.Entry(message).State = EntityState.Added;
            else
                _context.Entry(message).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteItem(Guid id)
        {
            _context.Items.Remove(new Item { Id = id});
            _context.SaveChanges();
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public IEnumerable<Item> GetMyItems(string userId)
        {
            var ADs = _context.Items.Where(x => x.ItemOwner == userId).ToList();
            foreach (var ad in ADs)
            {
                ad.ImgPath = GetAllItemImages(ad.Id);
                ad.ItemMesages = GetMessagesByItemId(ad.Id);
            }
            return ADs;
        }

        public async Task<List<Item>> FindItem(Expression<Func<Item, bool>> query)
        {
                return await _context.Items.Where(query).Select(x => x).ToListAsync();
        }

        public List<ItemImages> GetAllItemImages(Guid Id)
        {
            return _context.ItemImages.Where(x => x.Item.Id == Id).ToList();
        }

        public IEnumerable<Item> GetPaginatedItems(int Count, int Page = 1)
        {
            if (Page == 1)
            {
                return _context.Items.Take(Count).ToList();
            }
            else
            return _context.Items.Skip(Page-1 * Count).Take(Count).ToList();
        }

        public List<PM> GetMessagesByItemId(Guid ID)
        {
            return _context.PMs.Where(x => x.ItemId == ID).ToList();
        }
    }
}