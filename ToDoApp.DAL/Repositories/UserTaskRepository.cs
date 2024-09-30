using ErrorOr;
using Microsoft.EntityFrameworkCore;
using ToDoApp.DAL.Data;
using ToDoApp.DAL.Entities;
using ToDoApp.DAL.Repositories.Interfaces;

namespace ToDoApp.DAL.Repositories;

public class UserTaskRepository : IUserTaskRepository
{
    private readonly ToDoAppDbContext _context;

    public UserTaskRepository(
        ToDoAppDbContext context)
    {
        _context = context;
    }
    
    private async Task<UserTask?> FindUserTaskByIdAsync(int taskId)
    {
        return await _context.UserTasks
            .Include(ut => ut.Categories)
            .FirstOrDefaultAsync(ut => ut.Id == taskId);
    }

    public async Task<List<UserTask>> GetPagedTasksAsync(int pageNumber, int pageSize, List<int>? categoryIds, string? searchTerm, string userId)
    {
        var query = _context.UserTasks
             .Where(ut => ut.UserId == userId && ut.Categories.Any(c => categoryIds.Contains(c.Id)))
             .Include(c=>c.Categories)
             .AsQueryable();

        
        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(t => t.Name.Contains(searchTerm) || t.Description.Contains(searchTerm));
            var result = query.ToList();
        }
        
        var tasks = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return tasks;
    }

    public async Task<ErrorOr<UserTask>> AddCategoriesAsync(int taskId, List<int> categoryIds)
    {
        var userTask = await FindUserTaskByIdAsync(taskId);
        
        if (userTask is null)
            return Error.NotFound();

        return await AddCategoriesAsync(userTask, categoryIds);
    }

    public async Task<ErrorOr<UserTask>> AddCategoriesAsync(UserTask userTask, List<int> categoryIds)
    {
        var categoriesToAdd = _context.Categories
            .Where(c => categoryIds.Contains(c.Id));
        
        if (categoryIds is null)
            return Error.NotFound();
        
        userTask.Categories.AddRange(categoriesToAdd);

        return await SaveChangesOrReturnAsync(userTask);
    }

    public async Task<ErrorOr<UserTask>> CreateUserTask(UserTask userTask, List<int>? categoryIds)
    {
        _context.UserTasks.Add(userTask);
        
        if(categoryIds is not null)
            return await AddCategoriesAsync(userTask, categoryIds);
        
        return await SaveChangesOrReturnAsync(userTask);
    }
    
    private async Task<ErrorOr<UserTask>> SaveChangesOrReturnAsync(UserTask userTask)
    {
        try
        {
            await _context.SaveChangesAsync();
            return userTask;
        }
        catch
        {
            return Error.Failure();
        }
    }
}