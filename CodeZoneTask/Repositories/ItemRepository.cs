using CodeZoneTask.Contracts.Repositories;
using CodeZoneTask.Data;
using CodeZoneTask.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeZoneTask.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {

        public ItemRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Item?> GetByNameAsync(string itemName)
        {
            return await _context.Items.FirstOrDefaultAsync(item => item.Name == itemName);
        }

        public async Task<bool> IsItemExistsAsync(int itemId)
        {
            return await _context.Items.AnyAsync(e => e.Id == itemId);
        }

        public async Task<bool> IsItemNameExistsAsync(string itemName)
        {
            return await _context.Items.AnyAsync(item => item.Name == itemName);
        }
    }
}
