using ToDoApp.BLL.DTOs.Category;

namespace ToDoApp.BLL.DTOs.Task;

public class CreateUserTaskDto : BaseUserTaskDto
{
    public List<int>? CategoryIds { get; set; }
}