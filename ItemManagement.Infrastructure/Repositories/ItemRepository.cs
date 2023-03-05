using ItemManagement.Application.Interfaces.Repositories;
using ItemManagement.Domain.Models;
using ItemManagement.Infrastructure.Extensions.EfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _context;

        public ItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Item>> GetAll()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<bool> Update(Item item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
