using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence;

public class CleanArchitectureDbContext(DbContextOptions<CleanArchitectureDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanArchitectureDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}