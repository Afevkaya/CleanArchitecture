using CleanArchitecture.Application.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace CleanArchitecture.Caching;

public class CacheService(IMemoryCache memoryCache):ICacheService
{
    public Task<T?> GetAsync<T>(string key)
    {
        return Task.FromResult(memoryCache.TryGetValue(key, out T? cacheItem) ? cacheItem : default(T)!);
    }

    public Task SetAsync<T>(string key, T value, TimeSpan? absoluteExpireTime = null)
    {
        var options = new MemoryCacheEntryOptions();
        if (absoluteExpireTime.HasValue)
        {
            options.SetAbsoluteExpiration(absoluteExpireTime.Value);
        }
        memoryCache.Set(key, value, options);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(string key)
    {
        memoryCache.Remove(key);
        return Task.CompletedTask;
    }
}