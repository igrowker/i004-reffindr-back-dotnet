using Reffindr.Domain.Models;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Response.Property;

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

    public static PropertyPostResponseDto ToResponse(this Property property)
    {
        return new PropertyPostResponseDto
        {
            CountryId = property.CountryId,
            StateId = property.StateId,
            Title = property.Title,
            Address = property.Address,
            Environments = property.Environments,
            Bathrooms = property.Bathrooms,
            Bedrooms = property.Bedrooms,
            Seniority = property.Seniority,
            Water = property.Water,
            Gas = property.Gas,
            Surveillance = property.Surveillance,
            Electricity = property.Electricity,
            Internet = property.Internet,
            Pool = property.Pool,
            Garage = property.Garage,
            Pets = property.Pets,
            Grill = property.Grill,
            Elevator = property.Elevator,
            Terrace = property.Terrace,
            Description = property.Description,

           
        };
    }
}
