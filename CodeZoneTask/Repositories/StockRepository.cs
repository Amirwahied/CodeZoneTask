using CodeZoneTask.Contracts.Repositories;
using CodeZoneTask.Data;
using CodeZoneTask.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeZoneTask.Repositories
{
    public class StockRepository : GenericRepository<Stock>, IStockRepository
    {
        public StockRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Stock?> GetByNameAsync(string StockName)
        {
            return await _context.Stocks.FirstOrDefaultAsync(stock => stock.Name == StockName);
        }

        public async Task<bool> IsStockExists(int stockId)
        {
            return await _context.Stocks.AnyAsync(e => e.Id == stockId);
        }

        public async Task<bool> IsStockNameExistsAsync(string StockName)
        {
            return await _context.Stocks.AnyAsync(stock => stock.Name == StockName);
        }
    }
}
