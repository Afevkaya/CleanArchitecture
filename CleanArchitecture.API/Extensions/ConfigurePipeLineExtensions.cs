namespace CleanArchitecture.API.Extensions;

public static class ConfigurePipeLineExtensions
{
    public static IApplicationBuilder ConfigurePipelineExt(this WebApplication app)
    {
        app.UseExceptionHandler(x=>{});
        if (app.Environment.IsDevelopment())
            app.UseSwaggerExt();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        return app;
    }
}