using ErrorOr;
using Microsoft.AspNetCore.Identity;
using ToDoApp.BLL.DTOs.Auth;

namespace ToDoApp.BLL.Services.Interfaces;

public interface IAuthService
{
    Task<ErrorOr<UserDto>> Register(RegisterRequestDto requestDto);

    Task<ErrorOr<UserLoginDto>> Login(LoginRequestDto requestDto);
}