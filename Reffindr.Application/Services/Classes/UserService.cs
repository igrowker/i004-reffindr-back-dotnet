using Reffindr.Application.Services.Interfaces;
using Reffindr.Application.Utilities.Mappers;
using Reffindr.Domain.Models;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Response.Property;

namespace Reffindr.Application.Services.Classes;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;

    public UserService
        (
            IUnitOfWork unitOfWork,
            IUserContext userContext 
        )
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
    }

    public async Task<List<PropertyGetResponseDto>> GetOwnerPropertiesAsync()
    {
        int userOwnerId = _userContext.GetUserId();
        List<Property>? ownerProperties = await _unitOfWork.PropertiesRepository.GetOwnerProperties(userOwnerId);

        List<PropertyGetResponseDto>? ownerPropertiesResponse = ownerProperties!.Select(x => x.ToResponse()).ToList();
        return ownerPropertiesResponse;
    }

}
