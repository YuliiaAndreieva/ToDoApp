using FluentValidation;
using ToDoApp.BLL.DTOs.Task;

namespace ToDoApp.BLL.Validation.UserTask;

public class BaseUserTaskDtoValidator : AbstractValidator<BaseUserTaskDto>
{
    public BaseUserTaskDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .MinimumLength(3)
            .WithMessage("The name must be longer")
            .MaximumLength(20)
            .WithMessage("The name must be shorter ");
        
        RuleFor(c => c.DueDate)
            .NotNull()
            .GreaterThanOrEqualTo(DateTime.Now.AddDays(-1))
            .WithMessage("The due date must be from yesterday or later.");
        
        RuleFor(us => us.Description)
            .MinimumLength(3)
            .WithMessage("The description must be longer")
            .MaximumLength(150)
            .WithMessage("The description must be shorter ");
    }
}
