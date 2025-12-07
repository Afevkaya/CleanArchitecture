namespace CleanArchitecture.Application.Caching;

public interface ICacheService
{
    Task<T?> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T value, TimeSpan? absoluteExpireTime = null);
    Task RemoveAsync(string key);
}