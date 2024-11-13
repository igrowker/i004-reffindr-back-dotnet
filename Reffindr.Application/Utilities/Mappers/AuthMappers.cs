using Reffindr.Domain.Models;
using Reffindr.Shared.DTOs.Request.Auth;
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
            Role = userRegisterRequestDto.Role,
        };
    }
    public static UserRegisterResponseDto ToResponseDto(this User user, string token) 
    {
        return new UserRegisterResponseDto
        {
            Email = user.Email,
            Token = token
            
        };
    }

}
