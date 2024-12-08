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
            Environments = propertyPostRequestDto.Environments,
            Bathrooms = propertyPostRequestDto.Bathrooms,
            Bedrooms = propertyPostRequestDto.Bedrooms,
            Seniority = propertyPostRequestDto.Seniority,
            Water = propertyPostRequestDto.Water,
            Gas = propertyPostRequestDto.Gas,
            Surveillance = propertyPostRequestDto.Surveillance,
            Electricity = propertyPostRequestDto.Electricity,
            Internet = propertyPostRequestDto.Internet,
            Pool = propertyPostRequestDto.Pool,
            Garage = propertyPostRequestDto.Garage,
            Pets = propertyPostRequestDto.Pets,
            Grill = propertyPostRequestDto.Grill,
            Elevator = propertyPostRequestDto.Elevator,
            Terrace = propertyPostRequestDto.Terrace,
            Price = propertyPostRequestDto.Price,
            Requirement = new Requirement
            {
                IsWorking = propertyPostRequestDto.RequirementPostRequestDto!.IsWorking,
                HasWarranty = propertyPostRequestDto.RequirementPostRequestDto!.HasWarranty,
                RangeSalary = propertyPostRequestDto.RequirementPostRequestDto!.RangeSalary,
                
            }
        };
    }

    public static PropertyPostResponseDto ToPostResponse(this Property property)
    {
        return new PropertyPostResponseDto
        {
            Id = property.Id,
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
            Price = property.Price,
            Images = property.Images!.ImageUrl

        };
    }

    public static PropertyGetResponseDto ToResponse(this Property property)
    {
        return new PropertyGetResponseDto
        {
            Id = property.Id,
            Title = property.Title,
            Address = property.Address,
            Description = property.Description,
            CountryName = property.Country?.CountryName ?? "N/A",
            StateName = property.State?.StateName ?? "N/A",
            Price = property.Price,
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
            CountryId = property.CountryId,
            StateId = property.StateId,
            Images = property.Images?.ImageUrl ?? new List<string>()

        };
    } 
    
    public static PropertyPatchResponseDto ToPatchResponse(this Property property)
    {
        return new PropertyPatchResponseDto
        {
             PropertyId = property.Id,
             TenantId = property.TenantId,
             OwnerId = property.OwnerId

        };
    }
}
