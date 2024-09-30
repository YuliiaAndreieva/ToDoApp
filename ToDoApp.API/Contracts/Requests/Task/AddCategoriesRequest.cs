namespace ToDoApp.API.Contracts.Requests.Task;

public record AddCategoriesRequest(
    List<int> CategoryIds
    );