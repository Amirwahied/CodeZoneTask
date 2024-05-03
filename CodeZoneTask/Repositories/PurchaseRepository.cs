using CodeZoneTask.Contracts.Repositories;
using CodeZoneTask.Data;
using CodeZoneTask.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeZoneTask.Repositories
{
    public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<decimal> GetItemQuantit(int stockId, int itemId)
        {
            return await _context.Purchases
                     .Where(si => si.StockID == stockId && si.ItemID == itemId)
                     .SumAsync(x => x.Quantity);
        }
    }
}
