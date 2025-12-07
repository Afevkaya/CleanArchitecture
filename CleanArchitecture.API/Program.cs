using CleanArchitecture.API.ExceptionHandlers;
using CleanArchitecture.API.Extensions;
using CleanArchitecture.API.Filters;
using CleanArchitecture.Application.Caching;
using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Caching;
using CleanArchitecture.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithFiltersExt().AddSwaggerExt().AddOpenApiExt().AddExceptionHandlersExt().AddCachingExt();
builder.Services.AddRepositories(builder.Configuration).AddServices(builder.Configuration);


var app = builder.Build();
app.ConfigurePipelineExt();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();