using Reffindr.Domain.Models.UserModels;
using Reffindr.Shared.DTOs.Response.User;

namespace Reffindr.Application.Utilities.Mappers;

public static class UsersMappers
{
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
            IsProfileComplete = user.IsProfileComplete
        };
    }
}
