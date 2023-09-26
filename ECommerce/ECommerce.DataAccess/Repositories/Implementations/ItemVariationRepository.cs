using ECommerce.DataAccess.Entities;
using ECommerce.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Repositories.Implementations;

public class ItemVariationRepository : IItemVariation
{
    private readonly ApplicationDbContext _context;

    public ItemVariationRepository(ApplicationDbContext context)
    {
        this._context = context;
    }

    public async Task<ItemVariation> AddItemVariationAsync(ItemVariation itemVariation)
    {
        _context.ItemVariations.Add(itemVariation);
        await _context.SaveChangesAsync();
        
        return itemVariation;
    }

    public async Task<ItemVariation> DeleteItemVariationAsync(ItemVariation itemVariation)
    {
        _context.ItemVariations.Remove(itemVariation);
        await _context.SaveChangesAsync();

        return itemVariation;
    }

    public async Task<ItemVariation?> GetItemVariationByIdAsync(int id)
    {
        return await _context.ItemVariations.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<ItemVariation>> GetAllItemVariationsAsync()
    {
        return await _context.ItemVariations.AsNoTracking().ToListAsync();
    }

    public async Task<ItemVariation> UpdateItemVariationAsync(ItemVariation itemVariation)
    {
        _context.ItemVariations.Update(itemVariation);
        await _context.SaveChangesAsync();

        return itemVariation;
    }
}
