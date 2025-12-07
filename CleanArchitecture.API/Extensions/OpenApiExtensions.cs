using Swashbuckle.AspNetCore.SwaggerGen;

namespace CleanArchitecture.API.Extensions;

public static class OpenApiExtensions
{
    public static IServiceCollection AddOpenApiExt(this IServiceCollection services)
    {
        services.AddOpenApi();
        return services;
    }
}