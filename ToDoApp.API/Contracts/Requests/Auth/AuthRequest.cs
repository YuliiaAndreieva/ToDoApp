namespace ToDoApp.API.Contracts.Requests.Auth;

public record AuthRequest(
    string Email,
    string Password
    );