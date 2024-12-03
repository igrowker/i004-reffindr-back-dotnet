using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Shared.DTOs.Response.User;

namespace Reffindr.Application.Utilities.Mappers;

public static class UsersMappers
{
    public static User ToModel(this UserUpdateRequestDto userUpdateRequestDto)
    {
        return new User
        {
            CountryId = userUpdateRequestDto.CountryId,
            StateId = userUpdateRequestDto.StateId,
            Email = userUpdateRequestDto.Email!,
            Name = userUpdateRequestDto.Name!,
            LastName = userUpdateRequestDto.LastName!,
            Dni = userUpdateRequestDto.Dni,
            Phone = userUpdateRequestDto.Phone,
            Address = userUpdateRequestDto.Address,
            BirthDate = userUpdateRequestDto.BirthDate,
        };
    }
    public static UserUpdateResponseDto ToResponse(this User user)
    {
        return new UserUpdateResponseDto
        {
            Email = user.Email,
            Name = user.Name,
            LastName = user.LastName,
            Dni = user.Dni,
            Phone = user.Phone,
            Address = user.Address,
            BirthDate = user.BirthDate,
            IsProfileComplete = user.IsProfileComplete,
            ImageUrl = user.Image!.ImageUrl
        };
    }

    public static UserCredentialsResponseDto ToUserCredentialsResponse(this User user)
    {
        return new UserCredentialsResponseDto
        {
            RoleId = user.RoleId,
            Email = user.Email,
            Name = user.Name,
            LastName = user.LastName,
            Dni = user.Dni,
            Phone = user.Phone,
            Address = user.Address,
            BirthDate = user.BirthDate,
            IsProfileComplete = user.IsProfileComplete
        };
    }
}
