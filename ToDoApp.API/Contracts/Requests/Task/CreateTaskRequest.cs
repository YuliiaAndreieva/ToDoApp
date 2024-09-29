namespace ToDoApp.API.Contracts.Requests.Task;

public record CreateTaskRequest(
    string Name,
    DateTime DueDate,
    string Description
    );