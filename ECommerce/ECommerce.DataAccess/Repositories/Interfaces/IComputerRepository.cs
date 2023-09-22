using ECommerce.DataAccess.Entities;

namespace ECommerce.DataAccess.Repositories.Interfaces;

public interface IComputerRepository
{
    public Task<Computer> AddAsync(Computer computer);
    public Task<Computer> UpdateAsync(Computer computer);
    public Task<Computer> DeleteAsync(Computer computer);
    public Task<List<Computer>> GetAllAsync();
    public Task<Computer?> GetByIdAsync(int id);
}
