using Reffindr.Domain.Models;
using Reffindr.Shared.DTOs.Request.Application;
using Reffindr.Shared.DTOs.Response.Application;
using Reffindr.Shared.DTOs.Response.User;

namespace Reffindr.Application.Utilities.Mappers;

public static class ApplicationsMappers
{
    public static ApplicationModel ToModel(this ApplicationPostRequestDto applicationPostRequestDto)
    {
        return new ApplicationModel
        {
            PropertyId = applicationPostRequestDto.PropertyId
        };
    }

    public static ApplicationPostResponseDto ToResponse(this ApplicationModel applicationModel)
    {
        return new ApplicationPostResponseDto
        {
            PropertyId = applicationModel.PropertyId
        };
    }

    public static ApplicationGetResponseDto ToGetResponse(this ApplicationModel applicationModel)
    { 
        return new ApplicationGetResponseDto
        {
            Id = applicationModel.Id,
            PropertyId = applicationModel.PropertyId,
            PropertyTitle = applicationModel.Property?.Title ?? "No title",
            PropertyAddress = applicationModel.Property?.Address ?? "No address",
            Status = applicationModel.Status ?? "Unknown",
            CreatedAt = applicationModel.CreatedAt
        };
    }
    public static ApplicationsWithUserGetResponseDto ToApplicationsWithUserResponse(this ApplicationModel applicationModel)
    {
        return new ApplicationsWithUserGetResponseDto
        {
            Id = applicationModel.Id,
            PropertyId = applicationModel.PropertyId,
            PropertyTitle = applicationModel.Property?.Title ?? "No title",
            PropertyAddress = applicationModel.Property?.Address ?? "No address",
            Status = applicationModel.Status ?? "Unknown",
            CreatedAt = applicationModel.CreatedAt,
            UserResponseDto = new UserResponseDto()
            {
                Address = applicationModel.User!.Address,
                BirthDate = applicationModel.User!.BirthDate,
                CountryId = applicationModel.User!.CountryId,
                Dni = applicationModel.User!.Dni,
                GenreId = applicationModel.User!.GenreId,
                IsProfileComplete = applicationModel.User!.IsProfileComplete,
                LastName = applicationModel.User!.LastName,
                Name = applicationModel.User!.Name,
                Phone = applicationModel.User!.Phone,
                StateId = applicationModel.User!.StateId
            }
        };
    }
}
