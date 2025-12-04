using System.Linq.Expressions;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence;

public class GenericRepository<T,TId>(CleanArchitectureDbContext dbContext) : IGenericRepository<T, TId> 
    where T : BaseEntity<TId> where TId : struct
{
    protected readonly CleanArchitectureDbContext _dbContext = dbContext;
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();
    
    public Task<bool> AnyAsync(TId id) => _dbSet.AnyAsync(x=>x.Id!.Equals(id));
    public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return _dbSet.AnyAsync(expression);
    }
    public Task<List<T>> GetAllAsync()
    {
        return _dbSet.AsNoTracking().ToListAsync();
    }
    public IQueryable<T> GetAll() => _dbSet.AsQueryable().AsNoTracking();
    public IQueryable<T> Where(Expression<Func<T, bool>> expression) => _dbSet.Where(expression).AsNoTracking();
    public async ValueTask<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
    public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity);
    public void Update(T entity) => _dbSet.Update(entity);
    public void Delete(T entity) => _dbSet.Remove(entity);
}