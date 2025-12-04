using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Categories;

public class CategoryRepository(CleanArchitectureDbContext dbContext) :GenericRepository<Category,Guid>(dbContext), ICategoryRepository
{
    public Task<Category?> GetCategoryWithProductsAsync(Guid id)
    {
        return _dbContext.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
    }

    public Task<List<Category>> GetCategoriesWithProductsAsync()
    {
        return _dbContext.Categories.Include(c => c.Products).ToListAsync();
    }

    public IQueryable<Category?> GetCategoriesWithProducts()
    {
        return _dbContext.Categories.Include(c => c.Products).AsQueryable();
    }
}