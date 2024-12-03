using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Shared.DTOs.Response.User;

namespace Reffindr.Application.Utilities.Mappers;

public static class UsersMappers
{
    public static User ToModel(this UserUpdateRequestDto userUpdateRequestDto, User existingData)
    {

        userUpdateRequestDto.CountryId = existingData.CountryId;
        userUpdateRequestDto.StateId = existingData.StateId;
        userUpdateRequestDto.Email = existingData.Email!;
        userUpdateRequestDto.Name = existingData.Name!;
        userUpdateRequestDto.LastName = existingData.LastName!;
        userUpdateRequestDto.Dni = existingData.Dni;
        userUpdateRequestDto.Phone = existingData.Phone;
        userUpdateRequestDto.Address = existingData.Address;
        userUpdateRequestDto.BirthDate = existingData.BirthDate;

        return existingData;
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
