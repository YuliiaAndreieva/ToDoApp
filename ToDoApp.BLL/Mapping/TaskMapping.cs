using ToDoApp.BLL.DTOs.Task;
using ToDoApp.DAL.Entities;

namespace ToDoApp.BLL.Mapping;

public static class TaskMapping
{
    public static List<UserTaskDto> ToListDtos(
        this List<UserTask> userTasks)
    {
        return userTasks.Select(task => task.ToDto()).ToList();
    }
    
    public static UserTaskDto ToDto(
        this UserTask task)
    {
        return new UserTaskDto()
        {
            Id = task.Id,
            Name = task.Name,
            Description = task.Description,
            DueDate = task.DueDate,
            IsDone = task.isDone,
            CategoryDtos= task.Categories?.Select(c => c.ToDto()).ToList()
        };
    }
}