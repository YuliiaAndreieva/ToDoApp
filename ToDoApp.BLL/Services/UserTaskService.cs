using ErrorOr;
using FluentValidation;
using ToDoApp.BLL.DTOs;
using ToDoApp.BLL.DTOs.Category;
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
    private readonly IValidator<CreateUserTaskDto> _createUserTaskValidator;

    public UserTaskService(
        IUserTaskRepository taskRepository,
        ICurrentUserService currentUserService,
        IValidator<CreateUserTaskDto> createUserTaskValidator)
    {
        _taskRepository = taskRepository;
        _currentUserService = currentUserService;
        _createUserTaskValidator = createUserTaskValidator;
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

    public async Task<ErrorOr<UserTaskDto>> CreateUserTaskAsync(CreateUserTaskDto dto)
    {
        var validationResult = await _createUserTaskValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            return validationResult.ToErrorOr<UserTaskDto>();
        }
        
        var userTaskEntity = dto.ToEntity();
        //userTaskEntity.UserId = _currentUserService.UserId;
        userTaskEntity.UserId = "1646b8b7-3436-4a0a-b6f2-a997161ed735";
        var result = await _taskRepository.CreateUserTask(userTaskEntity, dto.CategoryIds);

        return result.IsError ? result.Errors : result.Value.ToDto();
    }
}