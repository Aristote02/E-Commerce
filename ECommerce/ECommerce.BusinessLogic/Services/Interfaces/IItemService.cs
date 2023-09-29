using ECommerce.BusinessLogic.DTO_s;
using ECommerce.BusinessLogic.Requests;

namespace ECommerce.BusinessLogic.Services.Interfaces
{
    public interface IItemService
    {
        Task<ItemDTO> AddItemAsync(ItemRequest itemRequest);
        Task<ItemDTO> UpdateItemAsync(int id, ItemRequest itemRequest);
        Task<ItemDTO> DeleteItemAsync(int id);
        Task<ItemDTO> GetItemByIdAsync(int id);
        Task<List<ItemDTO>> GetAllItemsAsync();
    }
}
