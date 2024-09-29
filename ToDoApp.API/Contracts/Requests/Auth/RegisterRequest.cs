namespace ToDoApp.API.Contracts.Requests.Auth;

public record RegisterRequest(
    string Name,
    string Email,
    string Password
    );