namespace ToDoApp.BLL.DTOs.Task;

public class PagedUserTasksRequestDto
{
    public string? SearchTerm { get; set; }
    
    public List<int>? CategoryIds { get; set; }
    
    public int Page { get; set; }
    
    public int PageSize { get; set; }
}