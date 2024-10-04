using Microsoft.AspNetCore.Identity;
using ToDoApp.BLL.DTOs.Auth;

namespace ToDoApp.BLL.Mapping;

public static class UserMapping
{
    public static IdentityUser ToIdentityUser(
        this AuthRequestDto dto)
    {
        return new IdentityUser()
        {
            UserName = dto.Email,
            Email = dto.Email,
        };
    }
    
    public static UserDto ToUserDto(
        this IdentityUser identityUser)
    {
        return new UserDto()
        {
            Email = identityUser.NormalizedEmail,
            Name = identityUser.UserName
        };
    }
}