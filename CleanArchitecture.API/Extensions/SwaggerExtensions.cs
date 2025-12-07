using Microsoft.OpenApi.Models;

namespace CleanArchitecture.API.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerExt(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanArchitecture.API", Version = "v1" });
        });
        
        return services;
    }

    public static IApplicationBuilder UseSwaggerExt(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture.API v1"));
        
        return app;
    }
}