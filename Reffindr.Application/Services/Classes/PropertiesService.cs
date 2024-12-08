using MimeKit.Cryptography;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Application.Utilities.Mappers;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Filter;
using Reffindr.Shared.DTOs.Pagination;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Response.Notification;
using Reffindr.Shared.DTOs.Response.Property;
using Reffindr.Shared.Enum;
using Reffindr.Shared.Result;
using System.Reflection;

namespace Reffindr.Application.Services.Classes;

public class PropertiesService : IPropertiesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;
    private readonly IUserContext _userContext;
    private readonly IImageService _imageService;
    private readonly INotificationService _NotifyService;

    public PropertiesService
        (
             IUnitOfWork unitOfWork,
             IAuthService authService,
             IUserContext userContext,
             IImageService imageService,
             INotificationService notifyService

        )
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
        _userContext = userContext;
        _imageService = imageService;
        _NotifyService = notifyService;
    }

	public async Task<List<PropertyGetResponseDto>> GetOwnerPropertiesAsync()
    {
        int userOwnerId = _userContext.GetUserId();
        List<Property>? ownerProperties = await _unitOfWork.PropertiesRepository.GetOwnerProperties(userOwnerId);

        List<PropertyGetResponseDto>? ownerPropertiesResponse = ownerProperties!.Select(x => x.ToResponse()).ToList();
        return ownerPropertiesResponse;
    }

    public async Task<List<PropertyGetResponseDto>> GetTenantAnnounceAsync()
    {
        int userTenantId = _userContext.GetUserId();
        List<Property>? tenantAnnounces = await _unitOfWork.PropertiesRepository.GetTenantAnnounce(userTenantId);

        List<PropertyGetResponseDto>? tenantAnnouncesResponse = tenantAnnounces!.Select(x => x.ToResponse()).ToList();
        return tenantAnnouncesResponse;
    }

    public async Task<List<PropertyGetResponseDto>> GetPropertiesAsync(PropertyFilterDto filter, PaginationDto paginationDto)
    {
        //int userId = _userContext.GetUserId();

        // Validar los filtros, utilizaré fluent validation
        // var validationResult = new PropertyFilterDtoValidator().Validate(filter);

        var properties = await _unitOfWork.PropertiesRepository.GetPropertiesAsync(filter);
       
        List<PropertyGetResponseDto> propertyDtos = properties.Select(x => x.ToResponse()).ToList();

        return propertyDtos;
    }

    public async Task<PropertyGetResponseDto> GetPropertyAsync(int id)
    {
        Property propertyInDb = await _unitOfWork.PropertiesRepository.GetById(id);
        Country countryProperty = await _unitOfWork.CountryRepository.GetById(propertyInDb.CountryId);
        propertyInDb.Country = countryProperty;
        State stateProperty = await _unitOfWork.StateRepository.GetById(propertyInDb.CountryId);
        propertyInDb.State = stateProperty;
        PropertyGetResponseDto propertyResponse = propertyInDb.ToResponse();

        return propertyResponse;
    }

    public async Task<PropertyPostResponseDto> PostPropertyAsync(PropertyPostRequestDto propertyPostRequestDto, CancellationToken cancellationToken)
    {
        int userId = _userContext.GetUserId();
        User  userInDb = await _unitOfWork.UsersRepository.GetById(userId);
        Property propertyToCreate = propertyPostRequestDto.ToModel();

        propertyToCreate.TenantId = userId;
        propertyToCreate.IsDeleted = false;

        if (propertyPostRequestDto.Images != null)
        {
            List<string> imageUrls = await _imageService.UploadImagesAsync(propertyPostRequestDto.Images, cancellationToken);
            Image listImagesUpload = new Image
            {
                CreatedAt = DateTime.UtcNow,
                ImageUrl = imageUrls
            };
            await _unitOfWork.ImageRepository.Create(listImagesUpload, cancellationToken);

            propertyToCreate.Images = listImagesUpload;
        }

        Property registeredProperty = await _unitOfWork.PropertiesRepository.Create(propertyToCreate, cancellationToken);
        await _unitOfWork.Complete(cancellationToken);

        NotificationRequestDto notificationRequestDto = new NotificationRequestDto
        {
            Message = $"Hola , {userInDb.Name} {userInDb.LastName} ha creado una nueva propiedad {registeredProperty.Title} y la ha asignado a ti como propietario. Por favor, revisa esta propiedad y acepta o rechaza la asignación. Gracias El Equipo de Reffindr",
            UserToSendNotification = propertyPostRequestDto.OwnerEmail,
            Type = NotificationType.PropertyAssigned,
            PropertyId = registeredProperty.Id

        };
        await _NotifyService.SendNotification(notificationRequestDto, cancellationToken);

        PropertyPostResponseDto propertyPostResponseDto = registeredProperty.ToPostResponse();

        return propertyPostResponseDto;
    }

    public async Task<PropertyPatchResponseDto> ConfirmProperty(PropertyPatchRequestDto propertyConfirmPatchRequestDto, CancellationToken cancellationToken)
    {
        int userOwnerId = _userContext.GetUserId();
        User userOwnerInDb = await _unitOfWork.UsersRepository.GetById(userOwnerId);
        Property? property = await _unitOfWork.PropertiesRepository.GetById(propertyConfirmPatchRequestDto.PropertyId);
        User userTenatInDb = await _unitOfWork.UsersRepository.GetById(property.TenantId);

        property.OwnerId = userOwnerId;
        property.IsDeleted = false;
        property.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.PropertiesRepository.Update(propertyConfirmPatchRequestDto.PropertyId, property);

        List<Notification> updateNotification = await _unitOfWork.NotificationRepository.GetNotificationsByType(NotificationType.PropertyAssigned, cancellationToken);
        updateNotification.ForEach(notification => notification.IsRead = true);

        await _unitOfWork.NotificationRepository.UpdateList(updateNotification);
        await _unitOfWork.Complete(cancellationToken);


        NotificationRequestDto notificationRequest = new NotificationRequestDto
        {
            Message = $"Hola , El Propietario{userOwnerInDb.Name} {userOwnerInDb.LastName} ha aceptado tu solicitud de la propiedad {property.Title} . Gracias El Equipo de Reffindr",
            UserToSendNotification = userTenatInDb.Email,
            Type = NotificationType.PropertyAccepted,
            PropertyId = property.Id
        };
        await _NotifyService.SendNotification(notificationRequest, cancellationToken);


        PropertyPatchResponseDto propertyPatchResponse = property.ToPatchResponse();

        return propertyPatchResponse;

    }
	public async Task<PropertyDeleteResponseDto> DeletePropertyAsync(int id, CancellationToken cancellationToken)
	{
		int userId = _userContext.GetUserId();

		Property? property = await _unitOfWork.PropertiesRepository.GetByIdWithIncludeAsync(id);

		var response = new PropertyDeleteResponseDto
		{
			PropertyId = id,
			PropertyMatchesOwner = userId == property!.OwnerId || userId == property.TenantId
		};

		if (response.PropertyMatchesOwner)
		{
			await _unitOfWork.PropertiesRepository.SoftDelete(id);
            await _unitOfWork.ImageRepository.SoftDelete(property.Images!.Id);
            await _unitOfWork.RequimentsRepository.SoftDelete(property.Requirement!.Id);
            await _unitOfWork.Complete(cancellationToken);
		}

		return response;
	}
}
