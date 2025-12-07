using CleanArchitecture.API.Filters;
using CleanArchitecture.Application.Features.Categories;
using CleanArchitecture.Application.Features.Categories.Create;
using CleanArchitecture.Application.Features.Categories.Update;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

public class CategoriesController(ICategoryService categoryService): CustomBaseController
{
    [HttpGet("products")]
    public async Task<IActionResult> GetAllWithProducts() => CreateActionResult(await categoryService.GetAllWithProducts());
    
    [HttpGet("{id:guid}/products")]
    public async Task<IActionResult> GetWithProducts(Guid id) => CreateActionResult(await categoryService.GetWithProducts(id));
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync() => CreateActionResult(await categoryService.GetAllAsync());
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id) => CreateActionResult(await categoryService.GetByIdAsync(id));
    
    [HttpPost]
    public async Task<IActionResult> AddAsync(CreateCategoryRequest request) => CreateActionResult(await categoryService.AddAsync(request));
    
    [ServiceFilter(typeof(NotFoundFilter<Category, Guid>))]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id,UpdateCategoryRequest request) => CreateActionResult(await categoryService.UpdateAsync(id, request));
    
    [ServiceFilter(typeof(NotFoundFilter<Category, Guid>))]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id) => CreateActionResult(await categoryService.DeleteAsync(id));
}