using ErrorOr;
using FluentValidation;
using ToDoApp.BLL.DTOs.Task;
using ToDoApp.BLL.Helpers;
using ToDoApp.BLL.Mapping;
using ToDoApp.BLL.Services.Interfaces;
using ToDoApp.DAL.Common;
using ToDoApp.DAL.Entities;
using ToDoApp.DAL.Repositories.Interfaces;
using ToDoApp.DAL.Specifications;

namespace ToDoApp.BLL.Services;

public class UserTaskService : IUserTaskService
{
    private readonly IUserTaskRepository _taskRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IValidator<CreateUserTaskDto> _createUserTaskValidator;
    private readonly IValidator<UpdateUserTaskDto> _updateUserTaskValidator;
    private AndSpecification<UserTask> combinedSpecification;

    public UserTaskService(
        IUserTaskRepository taskRepository,
        ICurrentUserService currentUserService,
        IValidator<CreateUserTaskDto> createUserTaskValidator,
        IValidator<UpdateUserTaskDto> updateUserTaskValidator)
    {
        _taskRepository = taskRepository;
        _currentUserService = currentUserService;
        _createUserTaskValidator = createUserTaskValidator;
        _updateUserTaskValidator = updateUserTaskValidator;
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
        userTaskEntity.UserId = _currentUserService.UserId;
        
        var result = await _taskRepository.CreateUserTask(userTaskEntity, dto.CategoryIds);

        return result.IsError ? result.Errors : result.Value.ToDto();
    }
    
    public async Task<ErrorOr<Deleted>> DeleteUserTaskAsync(int id)
    {
        var result = await _taskRepository.DeleteUserTask(id);
        return result;
    }
    
    public async Task<ErrorOr<Updated>> UpdateUserTaskAsync(UpdateUserTaskDto dto)
    {
        var validationResult = await _updateUserTaskValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            return validationResult.ToErrorOr<Updated>();
        }
        
        var result = await _taskRepository.UpdateUserTaskAsync(dto.ToEntity());

        return result.IsError ? result.Errors : Result.Updated;
    }
    
    public async Task<PagedList<UserTaskDto>> GetTasksAsync(
        PagedUserTasksRequestDto pagedUserTaskDto)
    {
        string userId = _currentUserService.UserId;
        Specification<UserTask> combinedSpec = new UserIdSpecification(userId);
        
        if (pagedUserTaskDto.CategoryIds is not null && pagedUserTaskDto.CategoryIds.Any())
        {
            combinedSpec = combinedSpec.And(new CategorySpecification(pagedUserTaskDto.CategoryIds));
        }
        
        if (!string.IsNullOrWhiteSpace(pagedUserTaskDto.SearchTerm))
        {
            combinedSpec = combinedSpec.And(new SearchTermSpecification(pagedUserTaskDto.SearchTerm));
        }

        var pagedTasks= await _taskRepository.GetPagedTasksAsync(combinedSpec, pagedUserTaskDto.Page, pagedUserTaskDto.PageSize);
        return pagedTasks.ToListDtos();
    }
}