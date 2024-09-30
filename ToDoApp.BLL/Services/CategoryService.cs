using System.Runtime.InteropServices.JavaScript;
using ErrorOr;
using FluentValidation;
using ToDoApp.BLL.DTOs.Category;
using ToDoApp.BLL.Mapping;
using ToDoApp.BLL.Services.Interfaces;
using ToDoApp.DAL.Repositories.Interfaces;

namespace ToDoApp.BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly IValidator<CreateCategoryDto> _createCategoryValidator;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(
        IValidator<CreateCategoryDto> createCategoryValidator,
        ICategoryRepository categoryRepository)
    {
        _createCategoryValidator = createCategoryValidator;
        _categoryRepository = categoryRepository;
    }

    public async Task<ErrorOr<CategoryDto>> CreateCategoryAsync(
        CreateCategoryDto categoryDto)
    {
        var validationResult = await _createCategoryValidator.ValidateAsync(categoryDto);
        if (!validationResult.IsValid)
        {
            return validationResult.ToErrorOr<CategoryDto>();
        }
        
        var result = await _categoryRepository.AddCategoryAsync(categoryDto.ToEntity());
        
        return result.IsError ? result.Errors : result.Value.ToDto();
    }
}