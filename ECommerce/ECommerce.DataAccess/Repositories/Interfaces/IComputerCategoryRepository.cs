using ECommerce.DataAccess.Entities;

namespace ECommerce.DataAccess.Repositories.Interfaces;

public interface IComputerCategoryRepository
{
    Task<List<ComputerCategory>> GetAllcomputerCategoriesAsync();
    Task<ComputerCategory?> GetComputerCategoryByIdAsync(int id);
    Task<ComputerCategory> AddAsync(ComputerCategory computerCategory);
    Task<ComputerCategory> UpdateAsync(ComputerCategory computerCategory);
    Task<ComputerCategory> DeleteAsync(ComputerCategory computerCategory);
}
