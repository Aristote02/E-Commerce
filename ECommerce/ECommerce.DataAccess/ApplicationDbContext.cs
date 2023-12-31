﻿using ECommerce.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
            
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemVariation> ItemVariations { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<Role>().HasData(new List<Role>
        {
           new Role
           {
               Id = -2,
               Name = "user"
           },
           new Role
           {
               Id = -1,
               Name = "admin"
           }
        });

        modelBuilder.Entity<User>().HasData(new User
        {
            Id = -1,
            UserName = "Aristote",
            Email = "aristote@gmail.com",
            Password = "Aris021122000",
            RoleId = -1,
        });
    }
}
