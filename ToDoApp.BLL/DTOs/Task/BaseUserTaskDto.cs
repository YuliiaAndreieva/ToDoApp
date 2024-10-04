namespace ToDoApp.BLL.DTOs.Task;

public class BaseUserTaskDto
{
    public string Name { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsDone { get; set; }
    
    public List<int>? CategoryIds { get; set; }
}