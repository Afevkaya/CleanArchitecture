namespace CleanArchitecture.Application.Features.Products.Create;

public record CreateProductRequest(string Name, decimal Price, int Stock, Guid CategoryId);