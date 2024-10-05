using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.Contracts.Requests.Task;
using ToDoApp.API.Mapping;
using ToDoApp.BLL.Services.Interfaces;

namespace ToDoApp.API.Controllers;

[ApiController]
[Authorize]
public class UserTaskController : ControllerBase
{
    private readonly IUserTaskService _taskService;

    public UserTaskController(
        IUserTaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("api/tasks")]
    public async Task<IActionResult> GetTasks([FromQuery] GetPagedUserTasksRequest request)
    {
        var tasks = await _taskService.GetTasksAsync(request.ToDto());
    
        return Ok(tasks);
    }
    
    [HttpPost("api/tasks/{id}/categories")]
    public async Task<IActionResult> AddCategory([FromQuery] AddCategoriesRequest request, int id)
    {
        var result = await _taskService.AddCategoriesAsync(request.ToDto(id));
    
        return result.Match<IActionResult>(
            userTask => Ok(userTask), 
            errors => Problem(errors.ToResponse()) 
        );
    }
    
    [HttpPost("api/tasks")]
    public async Task<IActionResult> CreateUserTask(CreateUserTaskRequest request)
    {
        var result = await _taskService.CreateUserTaskAsync(request.ToDto());
    
        return result.Match<IActionResult>(
            userTask => Ok(userTask), 
            errors => Problem(errors.ToResponse()) 
        );
    }
    
    [HttpDelete("api/tasks/{id}")]
    public async Task<IActionResult> DeleteUserTask(int id)
    {
        var result = await _taskService.DeleteUserTaskAsync(id);
    
        return result.Match<IActionResult>(
            deleted => NoContent(), 
            errors => Problem(errors.ToResponse()) 
        );
    }
    
    [HttpPut("api/tasks/{id}")]
    public async Task<IActionResult> UpdateUserTask(UpdateUserTaskRequest request, int id)
    {
        var dto = (id, request).ToDto();
        var result = await _taskService.UpdateUserTaskAsync(dto);
    
        return result.Match<IActionResult>(
            deleted => NoContent(), 
            errors => Problem(errors.ToResponse()) 
        );
    }

    [HttpGet("api/tasks/{id}")]
    public async Task<IActionResult> GetUserTaskById(int id)
    {
        var userTask = await _taskService.GetUserTaskByIdAsync(id);
        return Ok(userTask);
    }
}