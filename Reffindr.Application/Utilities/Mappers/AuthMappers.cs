using Reffindr.Domain.Models.UserModels;
using Reffindr.Shared.DTOs.Request.Auth;
using Reffindr.Shared.DTOs.Request.User;
using Reffindr.Shared.DTOs.Response.Auth;

namespace Reffindr.Application.Utilities.Mappers;

public static class AuthMappers
{
    public static User ToModel(this UserRegisterRequestDto userRegisterRequestDto) 
    {
        return new User
        {
            Email = userRegisterRequestDto.Email,
            Name = userRegisterRequestDto.Name,
            LastName = userRegisterRequestDto.LastName,
            Password = userRegisterRequestDto.Password,
            RoleId = userRegisterRequestDto.RoleId,
        };
    }

    public static User ToModel(this UserLoginRequestDto userLoginRequestDto)
    {
        return new User
        {
            Email = userLoginRequestDto.Email,
            Password = userLoginRequestDto.Password,
        };
    }
    

    public static UserLoginResponseDto ToLoginResponseDto(this User user, string token)
    {
        return new UserLoginResponseDto
        {
            Token = token
        };
    }

    public static UserRegisterResponseDto ToRegisterResponseDto(this User user, string token) 
    {
        return new UserRegisterResponseDto
        {
            Email = user.Email,
            Token = token
            
        };
    }

}
