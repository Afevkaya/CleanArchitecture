using AutoMapper;
using CleanArchitecture.Application.Features.Categories.Create;
using CleanArchitecture.Application.Features.Categories.Dto;
using CleanArchitecture.Application.Features.Categories.Update;
using CleanArchitecture.Domain.Entities;
using NLayerArchitecture.Services.Categories.Dto;

namespace CleanArchitecture.Application.Features.Categories.Mapping;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<Category, CategoryWithProductsDto>();
        CreateMap<CreateCategoryResponse, Category>();
        CreateMap<UpdateCategoryResponse, Category>();
        CreateMap<CreateCategoryRequest, Category>()
            .ForMember(dest=>dest.Name,opt=>
                opt.MapFrom(src=>src.Name.ToLowerInvariant()));
        CreateMap<UpdateCategoryRequest, Category>()
            .ForMember(dest=>dest.Name,opt=>
                opt.MapFrom(src=>src.Name.ToLowerInvariant()));
    }
}