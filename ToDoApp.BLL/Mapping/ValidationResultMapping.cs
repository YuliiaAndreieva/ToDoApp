using ErrorOr;
using FluentValidation.Results;

namespace ToDoApp.BLL.Mapping;

public static class ValidationResultMapping
{
    public static ErrorOr<TResult> ToValidationErrors<TResult>(this ValidationResult validationResult)
    {
        return validationResult.Errors.ConvertAll(vf => Error.Validation(vf.PropertyName, vf.ErrorMessage));
    }
}