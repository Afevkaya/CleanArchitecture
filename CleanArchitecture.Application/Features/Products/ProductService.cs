using System.Net;
using AutoMapper;
using CleanArchitecture.Application.Caching;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Products.Create;
using CleanArchitecture.Application.Features.Products.Dto;
using CleanArchitecture.Application.Features.Products.Update;
using CleanArchitecture.Application.Features.Products.UpdateStock;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Products;

public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork,IMapper mapper, ICacheService cacheService):IProductService
{
    private const string CacheKey = "Products";
    public async Task<ServiceResult<List<ProductDto>>> GetAllAsync()
    {
        var productsFromCache = await cacheService.GetAsync<List<ProductDto>>(CacheKey);
        if(productsFromCache is not null) return ServiceResult<List<ProductDto>>.Success(productsFromCache);
        var products = await productRepository.GetAllAsync();
        var productDto = products.Select(mapper.Map<ProductDto>).ToList();
        await cacheService.SetAsync(CacheKey,productDto,TimeSpan.FromMinutes(10));
        return ServiceResult<List<ProductDto>>.Success(productDto);
    }
    public async Task<ServiceResult<ProductDto>> GetByIdAsync(Guid id)
    {
        var product = await productRepository.GetByIdAsync(id);
        if (product == null)
            return ServiceResult<ProductDto>.Failed("Ürün bulunamadı", HttpStatusCode.NotFound);
        
        var productDto = mapper.Map<ProductDto>(product);
        return ServiceResult<ProductDto>.Success(productDto);
    }
    public async Task<ServiceResult<List<ProductDto>>> GetTopPriceProductAsync(int count)
    {
        var products = await productRepository.GetTopPriceProductAsync(count);

        var productDto = products.Select(mapper.Map<ProductDto>).ToList();

        return ServiceResult<List<ProductDto>>.Success(productDto);
    }
    public async Task<ServiceResult<CreateProductResponse>> AddAsync(CreateProductRequest request)
    {
        // Manuel Exception
        // throw new CriticalException("Kritik hata");
        var anyProduct = await productRepository.AnyAsync(p=>p.Name == request.Name);
        if (anyProduct)
            return ServiceResult<CreateProductResponse>.Failed("Ürün ismi bulunmaktadır", HttpStatusCode.BadRequest);
        
        var product = mapper.Map<Product>(request);
        await productRepository.AddAsync(product) ;
        var result = await unitOfWork.SaveChangesAsync();
        return result > 0 
            ? ServiceResult<CreateProductResponse>.SuccessAsCreated(new CreateProductResponse(product.Id),$"api/products/{product.Id}") 
            : ServiceResult<CreateProductResponse>.Failed("Ürün eklenemedi");
    }
    public async Task<ServiceResult<UpdateProductResponse>> UpdateAsync(Guid id, UpdateProductRequest request)
    {
        if(id == Guid.Empty)
            return ServiceResult<UpdateProductResponse>.Failed("Ürün Id zorunludur");

        var isProductNameExist = await productRepository
            .AnyAsync(p => p.Name == request.Name && p.Id != id);
        
        if (isProductNameExist)
            return ServiceResult<UpdateProductResponse>.Failed("Ürün ismi bulunmaktadır", HttpStatusCode.BadRequest);
        
        var product = mapper.Map<Product>(request);
        product.Id = id;
        
        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync();
        
        return ServiceResult<UpdateProductResponse>.Success(new UpdateProductResponse(product.Id));
    }
    public async Task<ServiceResult<UpdateProductResponse>> UpdateStockAsync(UpdateProductStockRequest request)
    {
        if(request.Id == Guid.Empty)
            return ServiceResult<UpdateProductResponse>.Failed("Ürün Id zorunludur");
        
        var product = await productRepository.GetByIdAsync(request.Id);
        if (product == null)
            return ServiceResult<UpdateProductResponse>.Failed("Ürün bulunamadı",HttpStatusCode.NotFound);
        
        product.Stock = request.Stock;
        
        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync();
        
        return ServiceResult<UpdateProductResponse>.Success(new UpdateProductResponse(product.Id));
    }
    public async Task<ServiceResult> DeleteAsync(Guid id)
    {
        var product = await productRepository.GetByIdAsync(id);
        productRepository.Delete(product!);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }
    public async Task<ServiceResult<List<ProductDto>>> PaginationAsync(int page, int pageSize)
    {
        var paginationData = await productRepository.PaginationAsync(page, pageSize);
        if (paginationData.Count == 0)
            return ServiceResult<List<ProductDto>>.Failed("Girilen sayfada ürün bulunamadı", HttpStatusCode.NotFound);
        
        var productDto = paginationData.Select(mapper.Map<ProductDto>).ToList();
        return ServiceResult<List<ProductDto>>.Success(productDto);
    }
}