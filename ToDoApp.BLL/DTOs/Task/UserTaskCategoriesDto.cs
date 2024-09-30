namespace ToDoApp.BLL.DTOs.Task;

public class UserTaskCategoriesDto
{
    public int TaskId { get; set; }
    
    public List<int> CategoriesIds { get; set; }
}