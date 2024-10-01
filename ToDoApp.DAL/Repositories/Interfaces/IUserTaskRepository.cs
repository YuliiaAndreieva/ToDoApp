using ErrorOr;
using ToDoApp.DAL.Entities;

namespace ToDoApp.DAL.Repositories.Interfaces;

public interface IUserTaskRepository
{
    Task<List<UserTask>> GetPagedTasksAsync(
        int pageNumber,
        int pageSize,
        List<int> categoryIds,
        string userId,
        string? searchTerm);

    Task<ErrorOr<UserTask>> AddCategoriesAsync(
        int taskId, 
        List<int> categoryIds);

    Task<ErrorOr<UserTask>> CreateUserTask(
        UserTask userTask,
        List<int>? categoryIds);

    Task<ErrorOr<Deleted>> DeleteUserTask(
        int id);

    Task<ErrorOr<UserTask>> UpdateUserTaskAsync(
        UserTask updatedUserTask);
}