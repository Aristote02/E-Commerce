using ECommerce.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
            
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Computer> Computers { get; set; }
    public DbSet<ComputerCategory> ComputerCategories { get; set;}
}
