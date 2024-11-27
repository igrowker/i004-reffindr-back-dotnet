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
            Bathrooms = propertyPostRequestDto.Bathrooms,
            Bedrooms = propertyPostRequestDto.Bedrooms,
            Electricity = propertyPostRequestDto.Electricity,
            Elevator = propertyPostRequestDto.Elevator,
            Environments = propertyPostRequestDto.Environments,
            Garage = propertyPostRequestDto.Garage,
            Gas = propertyPostRequestDto.Gas,
            Grill = propertyPostRequestDto.Grill,
            Internet = propertyPostRequestDto.Internet,
            Pets = propertyPostRequestDto.Pets,
            Pool = propertyPostRequestDto.Pool,
            Price = propertyPostRequestDto.Price,
            Seniority = propertyPostRequestDto.Seniority,
            Surveillance = propertyPostRequestDto.Surveillance,
            Terrace = propertyPostRequestDto.Terrace,
            Water = propertyPostRequestDto.Water,
            
            Requirement = new Requirement
            {
                IsWorking = propertyPostRequestDto.RequirementPostRequestDto!.IsWorking,
                HasWarranty = propertyPostRequestDto.RequirementPostRequestDto!.HasWarranty,
                RangeSalary = propertyPostRequestDto.RequirementPostRequestDto!.RangeSalary,
                
            }
        };
    }

    public static PropertyGetResponseDto ToResponse(this Property property)
    {
        return new PropertyGetResponseDto
        {
            CountryId = property.CountryId,
            StateId = property.StateId,
            Title = property.Title,
            Address = property.Address,
            Description = property.Description,
            Bathrooms = property.Bathrooms,
            Bedrooms = property.Bedrooms,
            Electricity = property.Electricity,
            Elevator = property.Elevator,
            Environments = property.Environments,
            Garage = property.Garage,
            Gas = property.Gas,
            Grill = property.Grill,
            Internet = property.Internet,
            Pets = property.Pets,
            Pool = property.Pool,
            Price = property.Price,
            Seniority = property.Seniority,
            Surveillance = property.Surveillance,
            Terrace = property.Terrace,
            Water = property.Water,

            //Requirement = new Requirement
            //{
            //    IsWorking = propertyPostRequestDto.RequirementPostRequestDto!.IsWorking,
            //    HasWarranty = propertyPostRequestDto.RequirementPostRequestDto!.HasWarranty,
            //    RangeSalary = propertyPostRequestDto.RequirementPostRequestDto!.RangeSalary,

            //}
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
