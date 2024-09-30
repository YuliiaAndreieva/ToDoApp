namespace ToDoApp.API.Contracts.Requests.Task;

public record CreateUserTaskRequest(
    string Name,
    DateTime DueDate,
    string Description,
    List<int> CategoryIds 
    );