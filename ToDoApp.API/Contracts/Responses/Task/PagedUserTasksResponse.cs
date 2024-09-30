namespace ToDoApp.API.Contracts.Responses.Task;

public record PagedUserTasksResponse(
    int Page,
    int PageSize,
    bool HasPreviousPage,
    bool HasNextPage,
    List<UserTaskShortResponse> UserTasks
    );