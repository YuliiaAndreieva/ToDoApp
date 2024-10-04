
namespace ToDoApp.API.Contracts.Requests.Task;

public record GetPagedUserTasksRequest(
    List<int>? CategoryIds,
    string? SearchTerm,
    int Page = 1,
    int PageSize = 3
    );