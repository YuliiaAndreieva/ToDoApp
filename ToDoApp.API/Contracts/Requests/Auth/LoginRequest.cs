namespace ToDoApp.API.Contracts.Requests.Auth;

public record LoginRequest(
    string Email,
    string Password
    );