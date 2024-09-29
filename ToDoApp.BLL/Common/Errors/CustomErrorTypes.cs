using ErrorOr;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ToDoApp.BLL.Common.Errors;

public static class CustomErrorTypes
{
    public const int UserAlreadyExists = 1;

    public const int UserCreationFailed = 2;
    
    public const int UserNotFound = 3;
    
    public const int InvalidCredentials = 4;
}