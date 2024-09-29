using FluentValidation;
using ToDoApp.BLL.DTOs.Category;

namespace ToDoApp.BLL.Validation.Category;

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty()
            .Length(3, 20);
    }
}