using CodeZoneTask.Models.Entities;

namespace CodeZoneTask.Contracts.Repositories
{
    public interface IPurchaseRepository : IGenericRepository<Purchase>
    {
        //get total quantity of item inside stock
        Task<decimal> GetItemQuantit(int stockId, int itemId);
    }
}
