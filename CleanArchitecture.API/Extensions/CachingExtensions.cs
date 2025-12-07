using CleanArchitecture.Application.Caching;
using CleanArchitecture.Caching;

namespace CleanArchitecture.API.Extensions;

public static class CachingExtensions
{
    public static IServiceCollection AddCachingExt(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<ICacheService, CacheService>();
        return services;
    }
}