namespace ToDoApp.API.Contracts.Requests.Task;

public record CreateUserTaskRequest(
    string Name,
    DateTime DueDate,
    bool IsDone,
    string? Description,
    List<int>? CategoryIds 
    );