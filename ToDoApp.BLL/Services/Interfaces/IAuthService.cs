using ErrorOr;
using Microsoft.AspNetCore.Identity;
using ToDoApp.BLL.DTOs.Auth;

namespace ToDoApp.BLL.Services.Interfaces;

public interface IAuthService
{
    Task<ErrorOr<AuthResultDto>> Register(AuthRequestDto requestDto);

    Task<ErrorOr<AuthResultDto>> Login(AuthRequestDto requestDto);
}