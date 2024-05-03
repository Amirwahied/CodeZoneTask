using CodeZoneTask.Models.Entities;

namespace CodeZoneTask.Contracts.Repositories
{
    public interface IStockRepository : IGenericRepository<Stock>
    {
        //check if Stock is exist in database with id
        Task<bool> IsStockExists(int stockId);
        //check if Stock is exist in database with id
        Task<bool> IsStockNameExistsAsync(string StockName);
        //get Stock with name
        Task<Stock?> GetByNameAsync(string StockName);
    }
}
