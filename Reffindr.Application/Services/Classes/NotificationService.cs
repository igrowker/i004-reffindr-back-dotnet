using Microsoft.AspNetCore.SignalR;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Application.Utilities.Mappers;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Pagination;
using Reffindr.Shared.DTOs.Response.Notification;
using Reffindr.Shared.Enum;

namespace Reffindr.Application.Services.Classes
{
	public class NotificationService : INotificationService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserContext _userContext;
		private readonly IHubContext<NotificationHub> _hubContext;

		public NotificationService(IUnitOfWork unitOfWork, IUserContext userContext, IHubContext<NotificationHub> hubContext)
		{
			_unitOfWork = unitOfWork;
			_userContext = userContext;
			_hubContext = hubContext;
		}
		
		public async Task<List<NotificationResponseDto>> GetNotificationsAsync(PaginationDto paginationDto)
		{
			int userId = _userContext.GetUserId();

			List<Notification> notifications = await _unitOfWork.NotificationRepository.GetNotifications(userId, paginationDto);

			List<NotificationResponseDto> notificationsResponse = notifications.Select(x => x.ToResponse()).ToList();

			return notificationsResponse;
		}

		public async Task AddNotificationToUser(string userRecievingEmail,int propertyId, NotificationType Type, CancellationToken cancellationToken)
		{
			int userSenderId = _userContext.GetUserId();
			var userRecievingId = await _unitOfWork.UsersRepository.GetUserbyEmail(userRecievingEmail);


			Notification notification = new Notification()
			{
				UserReceivingId = userRecievingId.Id,
				Message = $"Tiene nueva notificacion de tipo {Type}",
				Type = Type.ToString(),
				Read = false,
				UserSenderId = userSenderId,
				PropertyId = propertyId,
			};
			await _unitOfWork.NotificationRepository.Create(notification, cancellationToken);
			await _hubContext.Clients.User(userRecievingId.Id.ToString()).SendAsync("ReceiveNotification", notification.Message);
		}

		public async Task ConfirmPropertyfromNotification(int propertyId)
		{

			Property? property = await _unitOfWork.PropertiesRepository.GetById(propertyId);
			property.IsDeleted = false;
			property.UpdatedAt = DateTime.UtcNow;
			await _unitOfWork.PropertiesRepository.Update(propertyId, property);
		}
	}

}
