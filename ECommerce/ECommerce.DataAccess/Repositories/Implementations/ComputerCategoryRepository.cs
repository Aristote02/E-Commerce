using ECommerce.DataAccess.Entities;
using ECommerce.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repositories.Implementations
{
    public class ComputerCategoryRepository : IComputerCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ComputerCategoryRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<ComputerCategory> AddAsync(ComputerCategory computerCategory)
        {
            _context.ComputerCategories.Add(computerCategory);
            await _context.SaveChangesAsync();

            return computerCategory;
        }

        public async Task<ComputerCategory> DeleteAsync(ComputerCategory computerCategory)
        {
            _context.ComputerCategories.Remove(computerCategory);
            await _context.SaveChangesAsync();

            return computerCategory;
        }

        public async Task<List<ComputerCategory>> GetAllcomputerCategoriesAsync()
        {
            return await _context.ComputerCategories.ToListAsync();
        }

        public async Task<ComputerCategory?> GetComputerCategoryByIdAsync(int id)
        {
            return await _context.ComputerCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComputerCategory> UpdateAsync(ComputerCategory computerCategory)
        {
            _context.ComputerCategories.Update(computerCategory);
            await _context.SaveChangesAsync();

            return computerCategory;
        }
    }
}
