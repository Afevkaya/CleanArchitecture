using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Contracts.Persistence;

public interface ICategoryRepository:IGenericRepository<Category,Guid>
{
    Task<Category?> GetCategoryWithProductsAsync(Guid id);
    Task<List<Category>> GetCategoriesWithProductsAsync();
}