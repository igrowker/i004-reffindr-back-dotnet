using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Shared.DTOs.Response.User;

namespace Reffindr.Application.Utilities.Mappers;

public static class UsersMappers
{
    public static User ToModel(this UserUpdateRequestDto userUpdateRequestDto, User existingData)
    {

        existingData.CountryId = userUpdateRequestDto.CountryId ?? existingData.CountryId;
        existingData.StateId = userUpdateRequestDto.StateId ?? existingData.StateId;
        existingData.Email = userUpdateRequestDto.Email! ?? existingData.Email;
        existingData.Name = userUpdateRequestDto.Name! ?? existingData.Name;
        existingData.LastName = userUpdateRequestDto.LastName! ?? existingData.LastName;
        existingData.Dni = userUpdateRequestDto.Dni ?? existingData.Dni;
        existingData.Phone = userUpdateRequestDto.Phone ?? existingData.Phone;
        existingData.Address = userUpdateRequestDto.Address ?? existingData.Address;
        existingData.BirthDate = userUpdateRequestDto.BirthDate ?? existingData.BirthDate;
        existingData.GenreId = userUpdateRequestDto.GenreId ?? existingData.GenreId;
        existingData.UserTenantInfo!.SalaryId = userUpdateRequestDto.SalaryId ?? existingData.UserTenantInfo.SalaryId;
        

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
            ImageUrl = user.Image!.ImageUrl,
            GenreId = user.GenreId,
            SalaryId = user.UserTenantInfo!.SalaryId

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
            IsProfileComplete = user.IsProfileComplete,
            ImageProfileUrl = user.Image!.ImageUrl,
            GenderId = user.GenreId,
            SalaryId = user.UserTenantInfo!.SalaryId
            

        };
    }
}
