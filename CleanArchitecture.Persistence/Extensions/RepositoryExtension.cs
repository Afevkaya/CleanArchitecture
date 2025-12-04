using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Options;
using CleanArchitecture.Persistence.Categories;
using CleanArchitecture.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLayerArchitecture.Repositories.Products;

namespace CleanArchitecture.Persistence.Extensions;

public static class RepositoryExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CleanArchitectureDbContext>(options =>
        {
            var connectionStrings = configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();
            options.UseSqlServer(connectionStrings!.SqlServer, sqlServerOptionsAction =>
            {
                sqlServerOptionsAction.MigrationsAssembly(typeof(PersistenceAssembly).Assembly.FullName);
            });
            options.AddInterceptors(new AuditDbContextInterceptor());
        });

        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
