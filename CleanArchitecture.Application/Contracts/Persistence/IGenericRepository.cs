using System.Linq.Expressions;

namespace CleanArchitecture.Application.Contracts.Persistence;

public interface IGenericRepository<T,TId> where T : class where TId : struct
{
    Task<bool> AnyAsync(TId id);
    Task<bool> AnyAsync(Expression<Func<T,bool>> expression);
    Task<List<T>> GetAllAsync();
    IQueryable<T> Where(Expression<Func<T,bool>> expression);
    ValueTask<T?> GetByIdAsync(Guid id);
    ValueTask AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}