using FluentValidation;
using ToDoApp.BLL.DTOs.Category;

namespace ToDoApp.BLL.Validation.Category;

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .MinimumLength(3)
            .WithMessage("The name must be longer")
            .MaximumLength(20)
            .WithMessage("The name must be shorter ");
    }
}