using CleanArchitecture.Application.Features.Products.Dto;

namespace CleanArchitecture.Application.Features.Categories.Dto;

public record CategoryWithProductsDto(Guid Id, string Name, DateTime CreatedDate, DateTime? UpdatedDate, List<ProductDto> Products);