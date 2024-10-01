using FluentValidation;
using ToDoApp.BLL.DTOs.Task;

namespace ToDoApp.BLL.Validation.UserTask;

public class UpdateUserTaskDtoValidator : AbstractValidator<UpdateUserTaskDto>
{
    public UpdateUserTaskDtoValidator()
    {
        Include(new BaseUserTaskDtoValidator());
    }
}