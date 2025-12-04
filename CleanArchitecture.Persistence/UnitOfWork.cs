using CleanArchitecture.Application.Contracts.Persistence;

namespace CleanArchitecture.Persistence;

public class UnitOfWork(CleanArchitectureDbContext dbContext):IUnitOfWork
{
    public Task<int> SaveChangesAsync() => dbContext.SaveChangesAsync();
}