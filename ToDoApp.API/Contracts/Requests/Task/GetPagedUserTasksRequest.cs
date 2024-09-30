using System.Runtime.InteropServices.JavaScript;

namespace ToDoApp.API.Contracts.Requests.Task;

public record GetPagedUserTasksRequest(
    List<int> categoryIds,
    string? searchTerm,
    int page = 1,
    int pageSize = 10
    );