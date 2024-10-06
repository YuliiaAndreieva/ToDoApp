using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.Contracts.Requests.Category;
using ToDoApp.API.Mapping;
using ToDoApp.BLL.Services.Interfaces;

namespace ToDoApp.API.Controllers;

[ApiController]
//[Authorize]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(
        ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("api/categories")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest categoryRequest)
    {
        var result = await _categoryService.CreateCategoryAsync(categoryRequest.ToDto());

        return result.Match<IActionResult>(
            category => Created($"/category/{category.Id}", category), 
            errors => Problem(errors.ToResponse()) 
        );
    }
    
    [HttpGet("api/categories")]
    public async Task<IActionResult> GetCategories()
    {
        var result = await _categoryService.GetCategoriesAsync();
        return Ok(result);
    }
}