using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Shared.DTOs.Request.Auth;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Request.Requirement;
using Reffindr.Shared.DTOs.Response.Auth;
using Reffindr.Shared.DTOs.Response.Property;
using Property = Reffindr.Domain.Models.Property;

namespace Reffindr.Application.Utilities.Mappers;

public static class AuthMappers
{
    public static User ToModel(this UserRegisterRequestDto userRegisterRequestDto) 
    {
        return new User
        {
            Email = userRegisterRequestDto.Email,
            Name = userRegisterRequestDto.Name,
            LastName = userRegisterRequestDto.LastName,
            Password = userRegisterRequestDto.Password,
            RoleId = userRegisterRequestDto.RoleId,
        };
    }

    public static User ToModel(this UserLoginRequestDto userLoginRequestDto)
    {
        return new User
        {
            Email = userLoginRequestDto.Email,
            Password = userLoginRequestDto.Password,
        };
    }
    public static Property ToModel(this PropertyPostRequestDto propertyPostRequestDto)
    {
        return new Property
        {
            CountryId = propertyPostRequestDto.CountryId,
            StateId = propertyPostRequestDto.StateId,
            Title = propertyPostRequestDto.Title,
            Address = propertyPostRequestDto.Address,
            Description = propertyPostRequestDto.Description,
            //Requirement = propertyPostRequestDto.RequirementPostRequestDto.Select(r => new Requirement
            //{

            //}).Tolist()
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

    public static UserLoginResponseDto ToLoginResponseDto(this User user, string token)
    {
        return new UserLoginResponseDto
        {
            Token = token
        };
    }

    public static UserRegisterResponseDto ToRegisterResponseDto(this User user, string token) 
    {
        return new UserRegisterResponseDto
        {
            Email = user.Email,
            Token = token
            
        };
    }

}
