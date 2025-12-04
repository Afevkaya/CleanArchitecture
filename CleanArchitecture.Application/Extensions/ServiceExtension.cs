using CleanArchitecture.Application.Features.Categories;
using CleanArchitecture.Application.Features.Products;
using CleanArchitecture.Application.Features.Products.Create;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        // TODO: Presentation layer'a taşınacak
        // services.AddScoped(typeof(NotFoundFilter<,>));
        // services.AddExceptionHandler<CriticalExceptionHandler>();
        // services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CreateProductRequestValidator>();
        services.AddAutoMapper(cfg => { }, typeof(ApplicationAssembly).Assembly);
        
        return services;
    }
}