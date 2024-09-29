using ErrorOr;
using Microsoft.AspNetCore.Identity;
using ToDoApp.BLL.Common.Errors;
using ToDoApp.BLL.DTOs.Auth;
using ToDoApp.BLL.Mapping;
using ToDoApp.BLL.Services.Interfaces;

namespace ToDoApp.BLL.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IJwtTokenService _tokenService;
    
    public AuthService(
        UserManager<IdentityUser> userManager,
        IJwtTokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<ErrorOr<UserDto>> Register(RegisterRequestDto requestDto)
    {
        var existingUser = await _userManager.FindByEmailAsync(requestDto.Email);
        if (existingUser is not null)
        {
            return AuthErrors.UserAlreadyExist;
        }

        var newUser = requestDto.ToIdentityUser();
        var result = await _userManager.CreateAsync(newUser, requestDto.Password);

        if (!result.Succeeded)
        {
            return AuthErrors.UserCreationFailed;
        }
        return newUser.ToUserDto();
    }

    public async Task<ErrorOr<UserLoginDto>> Login(LoginRequestDto requestDto)
    {
        var user = await _userManager.FindByEmailAsync(requestDto.Email);
        if (user is null)
            return AuthErrors.UserNotFound;
        
        var passwordCorrect = await _userManager.CheckPasswordAsync(user, requestDto.Password);
        if (!passwordCorrect)
            return AuthErrors.InvalidCredentials;

        var jwtToken = _tokenService.GenerateJwtToken(user);
        var userDto = new UserLoginDto() { Name = user.NormalizedUserName, Token = jwtToken };

        return userDto;
    }
}