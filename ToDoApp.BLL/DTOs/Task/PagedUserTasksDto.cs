namespace ToDoApp.BLL.DTOs.Task;

public class PagedUserTasksDto : PagedList<UserTaskDto> 
{
    public string SearchString { get; set; }
    public List<int>? CategoryIds { get; set; }
}