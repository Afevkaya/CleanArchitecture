namespace CleanArchitecture.Application.Features.Products.Dto;

public record ProductDto(Guid Id, string Name, decimal Price, int Stock, Guid CategoryId, DateTime CreatedDate, DateTime? UpdatedDate);