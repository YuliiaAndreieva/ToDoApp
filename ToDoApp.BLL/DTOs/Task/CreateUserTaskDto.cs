using ToDoApp.BLL.DTOs.Category;

namespace ToDoApp.BLL.DTOs.Task;

public class CreateUserTaskDto
{
    public string Name { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public string? Description { get; set; }
    
    public List<int>? CategoryIds { get; set; }
}