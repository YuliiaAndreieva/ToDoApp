using ErrorOr;
using ToDoApp.BLL.DTOs;
using ToDoApp.BLL.DTOs.Task;

namespace ToDoApp.BLL.Services.Interfaces;

public interface IUserTaskService
{
    Task<PagedList<UserTaskDto>> GetTasksAsync(PagedUserTasksDto getPagedTasksDto);

    Task<ErrorOr<UserTaskDto>> AddCategoriesAsync(UserTaskCategoriesDto userTaskCategoriesDto);

    Task<ErrorOr<UserTaskDto>> CreateUserTaskAsync(CreateUserTaskDto createUserTaskDto);
    
    Task<ErrorOr<Deleted>> DeleteUserTaskAsync(int id);

    Task<ErrorOr<Updated>> UpdateUserTaskAsync(UpdateUserTaskDto dto);
}