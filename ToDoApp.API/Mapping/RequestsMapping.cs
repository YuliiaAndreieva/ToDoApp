using Microsoft.AspNetCore.Identity.Data;
using ToDoApp.API.Contracts.Requests.Category;
using ToDoApp.BLL.DTOs.Auth;
using ToDoApp.BLL.DTOs.Category;

namespace ToDoApp.API.Mapping;

public static class RequestsMapping
{
    public static RegisterRequestDto ToRegisterRequestDto(
        this RegisterRequest registerRequest)
    {
        return new RegisterRequestDto(
            Name: registerRequest.Email,
            Email: registerRequest.Email,
            Password: registerRequest.Password
        );
    }
    
    public static LoginRequestDto ToLoginRequestDto(
        this LoginRequest loginRequest)
    {
        return new LoginRequestDto(
            Email: loginRequest.Email,
            Password: loginRequest.Password
        );
    }

    public static CreateCategoryDto ToDto(
        this CreateCategoryRequest createCategoryRequest)
    {
        return new CreateCategoryDto()
        {
            Name = createCategoryRequest.Name
        };
    }
}