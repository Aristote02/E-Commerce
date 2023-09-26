using ECommerce.DataAccess.Entities;

namespace ECommerce.DataAccess.Repositories.Interfaces;

public interface IItem
{
    Task<List<Item>> GetAllItemsAsync();
    Task<Item?> GetItemByIdAsync(int id);
    Task<Item> AddItemAsync(Item item);
    Task<Item> UpdateItemAsync(Item item);
    Task<Item> DeleteItem(Item item);
}
