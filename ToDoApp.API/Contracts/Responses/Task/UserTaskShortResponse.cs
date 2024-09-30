using ToDoApp.BLL.DTOs.Category;

namespace ToDoApp.API.Contracts.Responses.Task;

public record UserTaskShortResponse(
    int id,
    string name,
    bool isDone,
    List<CategoryDto> categories
    );