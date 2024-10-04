using ErrorOr;
using ToDoApp.DAL.Entities;

namespace ToDoApp.DAL.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<ErrorOr<Category>> AddCategoryAsync(Category category);

    Task<List<Category>> GetCategoriesAsync(string userId);
}