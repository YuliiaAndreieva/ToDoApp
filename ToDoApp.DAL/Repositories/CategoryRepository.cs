using ErrorOr;
using Microsoft.EntityFrameworkCore;
using ToDoApp.DAL.Data;
using ToDoApp.DAL.Entities;
using ToDoApp.DAL.Repositories.Interfaces;

namespace ToDoApp.DAL.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ToDoAppDbContext _context;

    public CategoryRepository(ToDoAppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ErrorOr<Category>> AddCategoryAsync(
        Category category)
    {
        try
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }
        catch
        {
            return Error.Failure();
        }
    }

    public async Task<List<Category>> GetCategoriesAsync(string userId)
    {
       return await _context.Categories
            .Where(c => c.Tasks.Any(t => t.UserId == userId))
            .ToListAsync();
    }
}