using ErrorOr;

namespace ToDoApp.BLL.Common.Errors;

public static class AuthErrors
{
    public static readonly Error UserAlreadyExist = Error.Custom(
        type: CustomErrorTypes.UserAlreadyExists,
        code: "User.AlreadyExists",
        description: "A user with this email already exists."
        );
    
    public static readonly Error UserCreationFailed = Error.Custom(
        type: CustomErrorTypes.UserCreationFailed,
        code: "User.CreationFailed",
        description: "An error occurred while creating the user. Please try again later."
    );
    
    public static readonly Error UserNotFound = Error.Custom(
        type: CustomErrorTypes.UserNotFound,
        code: "User.NotFound",
        description: "The user with the provided credentials does not exist."
    );
    
    public static readonly Error InvalidCredentials = Error.Custom(
        type: CustomErrorTypes.InvalidCredentials,
        code: "User.InvalidCredentials",
        description: "The username or password is incorrect."
    );
}