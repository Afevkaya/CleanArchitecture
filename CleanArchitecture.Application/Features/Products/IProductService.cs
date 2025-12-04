using CleanArchitecture.Application.Features.Products.Create;
using CleanArchitecture.Application.Features.Products.Dto;
using CleanArchitecture.Application.Features.Products.Update;
using CleanArchitecture.Application.Features.Products.UpdateStock;

namespace CleanArchitecture.Application.Features.Products;

public interface IProductService
{
    Task<ServiceResult<ProductDto>> GetByIdAsync(Guid id);
    Task<ServiceResult<List<ProductDto>>> GetAllAsync();
    Task<ServiceResult<List<ProductDto>>> GetTopPriceProductAsync(int count);
    Task<ServiceResult<CreateProductResponse>> AddAsync(CreateProductRequest request);
    Task<ServiceResult<UpdateProductResponse>> UpdateAsync(Guid id,UpdateProductRequest request);
    Task<ServiceResult<UpdateProductResponse>> UpdateStockAsync(UpdateProductStockRequest request);
    Task<ServiceResult> DeleteAsync(Guid id);
    Task<ServiceResult<List<ProductDto>>> PaginationAsync(int page, int pageSize);
}