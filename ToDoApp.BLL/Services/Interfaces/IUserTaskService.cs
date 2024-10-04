using ErrorOr;
using ToDoApp.BLL.DTOs.Task;
using ToDoApp.DAL.Common;

namespace ToDoApp.BLL.Services.Interfaces;

public interface IUserTaskService
{
    Task<UserTaskDto> GetUserTaskByIdAsync(int userTaskId);
    
    Task<PagedList<UserTaskDto>> GetTasksAsync(PagedUserTasksRequestDto getPagedTasksDto);

    Task<ErrorOr<UserTaskDto>> AddCategoriesAsync(UserTaskCategoriesDto userTaskCategoriesDto);

    Task<ErrorOr<UserTaskDto>> CreateUserTaskAsync(CreateUserTaskDto createUserTaskDto);
    
    Task<ErrorOr<Deleted>> DeleteUserTaskAsync(int id);

    Task<ErrorOr<Updated>> UpdateUserTaskAsync(UpdateUserTaskDto dto);
}