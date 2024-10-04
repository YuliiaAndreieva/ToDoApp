using ToDoApp.BLL.DTOs.Category;
using ToDoApp.BLL.DTOs.Task;
using ToDoApp.DAL.Common;
using ToDoApp.DAL.Entities;

namespace ToDoApp.BLL.Mapping;

public static class UserTaskMapping
{
    public static PagedList<UserTaskDto> ToListDtos(
        this PagedList<UserTask> userTasks)
    {
        var userTaskDtos = userTasks.Items.Select(task => new UserTaskDto
        {
            Id = task.Id,
            UserId = task.UserId,
            Name = task.Name,
            Description = task.Description,
            DueDate = task.DueDate,
            IsDone = task.IsDone,
            CategoryDtos = task.Categories?.Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            }).ToList() ?? new List<CategoryDto>()
        }).ToList();

        return new PagedList<UserTaskDto>(userTaskDtos, userTasks.Page, userTasks.PageSize, userTasks.TotalCount);
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
            IsDone = task.IsDone,
            CategoryDtos= task.Categories?.Select(c => c.ToDto()).ToList()
        };
    }

    public static UserTask ToEntity(
        this CreateUserTaskDto dto)
    {
        return new UserTask()
        {
            Name = dto.Name,
            Description = dto.Description,
            DueDate = dto.DueDate,
            IsDone = dto.IsDone,
            Categories = new List<Category>()
        };
    }
    public static UserTask ToEntity(
        this UpdateUserTaskDto dto)
    {
        return new UserTask()
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            DueDate = dto.DueDate,
            IsDone = dto.IsDone,
            Categories = new List<Category>()
        };
    }
}