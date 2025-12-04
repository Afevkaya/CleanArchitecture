using CleanArchitecture.Application.Features.Categories.Create;
using CleanArchitecture.Application.Features.Categories.Dto;
using CleanArchitecture.Application.Features.Categories.Update;
using NLayerArchitecture.Services.Categories.Dto;

namespace CleanArchitecture.Application.Features.Categories;

public interface ICategoryService
{
    Task<ServiceResult<CategoryWithProductsDto>> GetWithProducts(Guid id);
    Task<ServiceResult<List<CategoryWithProductsDto>>> GetAllWithProducts();
    Task<ServiceResult<CategoryDto>> GetByIdAsync(Guid id);
    Task<ServiceResult<List<CategoryDto>>> GetAllAsync();
    Task<ServiceResult<CreateCategoryResponse>> AddAsync(CreateCategoryRequest request);
    Task<ServiceResult<UpdateCategoryResponse>> UpdateAsync(Guid id,UpdateCategoryRequest request);
    Task<ServiceResult> DeleteAsync(Guid id);
}