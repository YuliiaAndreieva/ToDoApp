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

    [HttpGet("tasks")]
    public async Task<IActionResult> GetTasks([FromQuery] GetPagedUserTasksRequest request)
    {
        var tasks = await _taskService.GetTasksAsync(request.ToDto());
    
        return Ok(tasks.ToResponse());
    }
    
    [HttpPost("tasks/{id}/categories")]
    public async Task<IActionResult> AddCategory([FromQuery] AddCategoriesRequest request, int id)
    {
        var result = await _taskService.AddCategoriesAsync(request.ToDto(id));
    
        return result.Match<IActionResult>(
            userTask => Ok(userTask), 
            errors => Problem(errors.ToResponse()) 
        );
    }
}