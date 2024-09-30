using ToDoApp.BLL.DTOs.Category;

namespace ToDoApp.API.Contracts.Responses.Task;

public record UserTaskShortResponse(
    int Id,
    string Name,
    bool IsDone,
    List<CategoryDto> Categories
    );