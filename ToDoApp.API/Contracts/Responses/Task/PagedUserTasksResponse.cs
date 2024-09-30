namespace ToDoApp.API.Contracts.Responses.Task;

public record PagedUserTasksResponse(
    int page,
    int pageSize,
    bool hasPreviousPage,
    bool hasNextPage,
    List<UserTaskShortResponse> userTasks
    );