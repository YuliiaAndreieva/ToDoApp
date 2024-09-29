using ErrorOr;
using ToDoApp.BLL.DTOs.Category;

namespace ToDoApp.BLL.Services.Interfaces;

public interface ICategoryService
{
    Task<ErrorOr<CategoryDto>> CreateCategoryAsync(CreateCategoryDto categoryDto);
}