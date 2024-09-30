using ToDoApp.BLL.DTOs.Category;

namespace ToDoApp.BLL.DTOs.Task;

public class UserTaskDto
{
    public int Id { get; set; }
    
    public string UserId { get; set; }
    
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public DateTime DueDate { get; set; }
    
    public bool IsDone { get; set; }
    
    public List<CategoryDto> CategoryDtos { get; set; }
}