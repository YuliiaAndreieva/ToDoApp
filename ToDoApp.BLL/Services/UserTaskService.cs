using ErrorOr;
using ToDoApp.BLL.DTOs;
using ToDoApp.BLL.DTOs.Task;
using ToDoApp.BLL.Helpers;
using ToDoApp.BLL.Mapping;
using ToDoApp.BLL.Services.Interfaces;
using ToDoApp.DAL.Repositories.Interfaces;

namespace ToDoApp.BLL.Services;

public class UserTaskService : IUserTaskService
{
    private readonly IUserTaskRepository _taskRepository;
    private readonly ICurrentUserService _currentUserService;

    public UserTaskService(
        IUserTaskRepository taskRepository,
        ICurrentUserService currentUserService)
    {
        _taskRepository = taskRepository;
        _currentUserService = currentUserService;
    }

    public async Task<PagedList<UserTaskDto>> GetTasksAsync(
        PagedUserTasksDto pagedTasksDto)
    {
        var userId = _currentUserService.UserId;
        
        var taskList = await _taskRepository.GetPagedTasksAsync(
            pagedTasksDto.Page, 
            pagedTasksDto.PageSize, 
            pagedTasksDto.CategoryIds,
            pagedTasksDto.SearchString,
            userId
            );

        pagedTasksDto.Items = taskList.ToListDtos();

        return pagedTasksDto;
    }

    public async Task<ErrorOr<UserTaskDto>> AddCategoriesAsync(UserTaskCategoriesDto dto)
    {
        var result = await _taskRepository.AddCategoriesAsync(dto.TaskId, dto.CategoryIds);

        return result.IsError ? result.Errors : result.Value.ToDto();
    }
}