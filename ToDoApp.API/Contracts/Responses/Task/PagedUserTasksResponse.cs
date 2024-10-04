namespace ToDoApp.API.Contracts.Responses.Task;

public record PagedUserTasksResponse(
    int Page,
    int PageSize,
    bool HasPreviousPage,
    bool HasNextPage,
    int TotalCount,
    List<UserTaskShortResponse> UserTasks
    );