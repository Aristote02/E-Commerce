using ECommerce.DataAccess.Entities;
using ECommerce.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Repositories.Implementations;

public class ComputerRepository : IComputerRepository
{
    private readonly ApplicationDbContext _context;
          
    /// <summary>
    /// Initializes a new instance of <see cref="ComputerRepository"/>
    /// </summary>
    /// <param name="context"></param>
    public ComputerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Computer> AddAsync(Computer computer)
    {
        _context.Computers.Add(computer);
        await _context.SaveChangesAsync();
        
        return computer;
    }

    public async Task<Computer> DeleteAsync(Computer computer)
    {
        _context.Computers.Remove(computer);
        await _context.SaveChangesAsync();

        return computer;
    }

    public async Task<List<Computer>> GetAllAsync()
    {
        return await _context.Computers.ToListAsync();
    }

    public async Task<Computer?> GetByIdAsync(int id)
    {
        return await _context.Computers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Computer> UpdateAsync(Computer computer)
    {
        _context.Computers.Update(computer);
        await _context.SaveChangesAsync();

        return computer;
    }
}
