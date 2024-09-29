namespace ToDoApp.BLL.DTOs.Task;

public record CreateTaskDto(
    string Name,
    DateTime DueDate,
    string Description
    );