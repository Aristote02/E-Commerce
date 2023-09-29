using ECommerce.BusinessLogic.DTO_s;
using ECommerce.BusinessLogic.Requests;

namespace ECommerce.BusinessLogic.Services.Interfaces;

public interface IItemVariationService
{
    Task<ItemVariationDTO> AddItemVariationAsync(ItemVariationRequest itemVariationRequest);
    Task<ItemVariationDTO> UpdateItemVariationAsync(int id, ItemVariationRequest itemVariationRequest);
    Task<ItemVariationDTO> DeleteItemVariationAsync(int id);
    Task<ItemVariationDTO> GetItemVariationByIdAsync(int id);
    Task<List<ItemVariationDTO>> GetAllItemsVariationAsync();
}
