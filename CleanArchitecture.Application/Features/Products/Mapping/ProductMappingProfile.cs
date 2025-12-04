using AutoMapper;
using CleanArchitecture.Application.Features.Products.Create;
using CleanArchitecture.Application.Features.Products.Dto;
using CleanArchitecture.Application.Features.Products.Update;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Products.Mapping;

public class ProductMappingProfile:Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductRequest, Product>()
            .ForMember(dest=>dest.Name,
                opt=>opt.MapFrom(src=>src.Name.ToLowerInvariant()));
        CreateMap<UpdateProductRequest, Product>().ForMember(dest=>dest.Name,
            opt=>opt.MapFrom(src=>src.Name.ToLowerInvariant()));
    }
}