using ErrorOr;
using FluentValidation;
using ToDoApp.BLL.DTOs.Category;
using ToDoApp.BLL.Helpers;
using ToDoApp.BLL.Mapping;
using ToDoApp.BLL.Services.Interfaces;
using ToDoApp.DAL.Repositories.Interfaces;

namespace ToDoApp.BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IValidator<CreateCategoryDto> _createCategoryValidator;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(
        IValidator<CreateCategoryDto> createCategoryValidator,
        ICategoryRepository categoryRepository,
        ICurrentUserService currentUserService)
    {
        _createCategoryValidator = createCategoryValidator;
        _categoryRepository = categoryRepository;
        _currentUserService = currentUserService;
    }

    public async Task<ErrorOr<CategoryDto>> CreateCategoryAsync(
        CreateCategoryDto categoryDto)
    {
        var validationResult = await _createCategoryValidator.ValidateAsync(categoryDto);
        if (!validationResult.IsValid)
        {
            return validationResult.ToErrorOr<CategoryDto>();
        }
        
        var category = categoryDto.ToEntity();
        category.UserId = _currentUserService.UserId;

        var result = await _categoryRepository.AddCategoryAsync(category);
        
        return result.IsError ? result.Errors : result.Value.ToDto();
    }
    
    public async Task<List<CategoryDto>> GetCategoriesAsync()
    {
        var categories = await _categoryRepository.GetCategoriesAsync(_currentUserService.UserId);
        return categories.ToListDtos();
    }
}