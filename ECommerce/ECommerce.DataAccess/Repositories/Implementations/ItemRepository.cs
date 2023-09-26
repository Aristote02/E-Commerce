using ECommerce.DataAccess.Entities;
using ECommerce.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Repositories.Implementations;

public class ItemRepository : IItem
{
    private readonly ApplicationDbContext _context;

    public ItemRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Item> AddItemAsync(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();

        return item;
    }

    public async Task<Item> DeleteItem(Item item)
    {
        _context.Items.Remove(item);
        await _context.SaveChangesAsync();

        return item;
    }

    public async Task<List<Item>> GetAllItemsAsync()
    {
        return await _context.Items.AsNoTracking().ToListAsync();
    }

    public async Task<Item?> GetItemByIdAsync(int id)
    {
        return await _context.Items.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Item> UpdateItemAsync(Item item)
    {
        _context.Items.Update(item);
        await _context.SaveChangesAsync();

        return item;
    }
}
