using ECommerce.DataAccess.Entities;

namespace ECommerce.DataAccess.Repositories.Interfaces;

public interface IItemVariation
{
    Task<List<ItemVariation>> GetAllItemVariationsAsync();
    Task<ItemVariation?> GetItemVariationByIdAsync(int id);
    Task<ItemVariation> AddItemVariationAsync(ItemVariation itemVariation);
    Task<ItemVariation> UpdateItemVariationAsync(ItemVariation itemVariation);
    Task<ItemVariation> DeleteItemVariationAsync(ItemVariation itemVariation);
}
