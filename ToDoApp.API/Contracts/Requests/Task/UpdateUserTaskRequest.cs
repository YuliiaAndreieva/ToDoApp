namespace ToDoApp.API.Contracts.Requests.Task;

public record UpdateUserTaskRequest(
    string Name,
    DateTime DueDate,
    string? Description,
    bool IsDone
    );