using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.Contracts.Requests.Task;
using ToDoApp.API.Mapping;
using ToDoApp.BLL.Services.Interfaces;

namespace ToDoApp.API.Controllers;

[ApiController]
public class TaskController : ControllerBase
{
    private readonly IUserTaskService _taskService;

    public TaskController(
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
    
    [HttpPost("tasks/{id}/category")]
    public async Task<IActionResult> AddCategory([FromQuery] AddCategoriesRequest request)
    {
        //var tasks = await _taskService.GetTasksAsync(request.ToDto());
    
        return Ok();
    }
}