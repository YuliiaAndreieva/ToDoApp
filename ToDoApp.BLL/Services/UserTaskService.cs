using ToDoApp.BLL.DTOs;
using ToDoApp.BLL.DTOs.Task;
using ToDoApp.BLL.Services.Interfaces;
using ToDoApp.DAL.Repositories.Interfaces;

namespace ToDoApp.BLL.Services;

public class TaskService : ITaskService
{
    private readonly IUserTaskRepository _taskRepository;

    public TaskService(
        IUserTaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public Task<PagedList<UserTaskDto>> GetTasksAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm,
        List<int>? categoryIds)
    {
        
    }
}