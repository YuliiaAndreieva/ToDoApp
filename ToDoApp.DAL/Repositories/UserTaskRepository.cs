using ErrorOr;
using Microsoft.EntityFrameworkCore;
using ToDoApp.DAL.Common;
using ToDoApp.DAL.Data;
using ToDoApp.DAL.Entities;
using ToDoApp.DAL.Repositories.Interfaces;
using ToDoApp.DAL.Specifications;

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
            .FirstOrDefaultAsync(ut => ut.Id == taskId);
    }

    public async Task<ErrorOr<UserTask>> AddCategoriesAsync(int taskId, List<int> categoryIds)
    {
        var userTask = await _context.UserTasks
            .Include(ut => ut.Categories)
            .FirstOrDefaultAsync(ut => ut.Id == taskId);
        
        if (userTask is null)
            return Error.NotFound();

        return await AddCategoriesAsync(userTask, categoryIds);
    }

    private async Task<ErrorOr<UserTask>> AddCategoriesAsync(UserTask userTask, List<int> categoryIds)
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
        await _context.UserTasks.AddAsync(userTask);
        
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
    
    public async Task<ErrorOr<Deleted>> DeleteUserTask(int id)
    {
        var userTask = await FindUserTaskByIdAsync(id);

        if (userTask is null)
            return Error.NotFound();
        
        _context.UserTasks.Remove(userTask);

        try
        {
            await _context.SaveChangesAsync();
            return Result.Deleted;
        }
        catch
        {
            return Error.Failure();
        }
    }
    
    public async Task<ErrorOr<UserTask>> UpdateUserTaskAsync(UserTask updatedUserTask)
    {
        var userTask = await FindUserTaskByIdAsync(updatedUserTask.Id);

        if (userTask is null)
            return Error.NotFound();

        UpdateUserTaskProperties(userTask, updatedUserTask);

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

    private static void UpdateUserTaskProperties(
        UserTask oldUserTask,
        UserTask updatedUserTask)
    {
        oldUserTask.Name = updatedUserTask.Name;
        oldUserTask.Description = updatedUserTask.Description;
        oldUserTask.DueDate = updatedUserTask.DueDate;
        oldUserTask.IsDone = updatedUserTask.IsDone;
    }
    
    public async Task<PagedList<UserTask>> GetPagedTasksAsync(Specification<UserTask> specification, int page, int pageSize)
    {
        var query = _context.UserTasks
            .Include(us=>us.Categories)
            .AsQueryable();
        
        if (specification is not null)
        {
            query = query.Where(specification.ToExpression());
        }
        
        var pagedTasks = await query.Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var totalCount = await query.CountAsync();
        
        return new PagedList<UserTask>(pagedTasks, page, pageSize, totalCount);
    }
}