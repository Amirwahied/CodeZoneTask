using CodeZoneTask.Models.Entities;

namespace CodeZoneTask.Contracts.Repositories
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        //check if item is exist in database with id
        Task<bool> IsItemExistsAsync(int itemId);
        //check if item is exist in database with id
        Task<bool> IsItemNameExistsAsync(string itemName);
        //get item with name
        Task<Item?> GetByNameAsync(string itemName);
    }
}
