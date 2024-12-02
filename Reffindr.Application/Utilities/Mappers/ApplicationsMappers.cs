using Reffindr.Domain.Models;
using Reffindr.Shared.DTOs.Request.Application;
using Reffindr.Shared.DTOs.Response.Application;

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
}
