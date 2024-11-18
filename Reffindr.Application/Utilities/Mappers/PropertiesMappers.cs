using Reffindr.Domain.Models;
using Reffindr.Shared.DTOs.Request.Property;

namespace Reffindr.Application.Utilities.Mappers;

public static class PropertiesMappers
{
    public static Property ToModel(this PropertyPostRequestDto propertyPostRequestDto)
    {
        return new Property
        {
            CountryId = propertyPostRequestDto.CountryId,
            StateId = propertyPostRequestDto.StateId,
            Title = propertyPostRequestDto.Title,
            Address = propertyPostRequestDto.Address,
            Description = propertyPostRequestDto.Description,
            Requirement = new Requirement
            {
                IsWorking = propertyPostRequestDto.RequirementPostRequestDto!.IsWorking,
                HasWarranty = propertyPostRequestDto.RequirementPostRequestDto!.HasWarranty,
                RangeSalary = propertyPostRequestDto.RequirementPostRequestDto!.RangeSalary,
                
            }
        };
    }
    
    //public static PropertyPostResponseDto ToResponse(this Property property )
    //{
    //    return new PropertyPostResponseDto
    //    {
    //        OwnerId = propertyPostRequestDto.OwnerId,
    //        TenantId = propertyPostRequestDto.TenantId,
    //        RequirementId = propertyPostRequestDto.RequirementId,
    //        CountryId = propertyPostRequestDto.CountryId,
    //        StateId = propertyPostRequestDto.StateId,
    //        Title = propertyPostRequestDto.Title,
    //        Address = propertyPostRequestDto.Address,
    //        Description = propertyPostRequestDto.Description,
    //    };
    //}
}
