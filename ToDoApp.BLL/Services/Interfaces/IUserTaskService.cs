using ToDoApp.BLL.DTOs;
using ToDoApp.BLL.DTOs.Task;
using ToDoApp.DAL.Entities;

namespace ToDoApp.BLL.Services.Interfaces;

public interface ITaskService
{
    Task<PagedList<UserTaskDto>> GetTasksAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm,
        List<int>? categoryIds);
}