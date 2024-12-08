using Microsoft.AspNetCore.SignalR;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Application.Utilities.Mappers;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.Repositories.Interfaces;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Pagination;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Response.Notification;
using Reffindr.Shared.Enum;

namespace Reffindr.Application.Services.Classes
{
	public class NotificationService : INotificationService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserContext _userContext;
		private readonly IUsersRepository _usersRepository;
		private readonly IHubContext<NotificationHub> _hubContext;

		public NotificationService(IUnitOfWork unitOfWork, IUserContext userContext,  IUsersRepository usersRepository, IHubContext<NotificationHub> hubContext)
		{
			_unitOfWork = unitOfWork;
			_userContext = userContext;
			_usersRepository = usersRepository;
			_hubContext = hubContext;
		}
		
		public async Task<List<NotificationResponseDto>> GetNotificationsAsync(PaginationDto paginationDto)
		{
			int userId = _userContext.GetUserId();

			List<Notification> notifications = await _unitOfWork.NotificationRepository.GetNotifications(paginationDto);

			List<NotificationResponseDto> notificationsResponse = notifications.Select(x => x.ToResponse()).ToList();

			return notificationsResponse;
		}

		public async Task <NotificationResponseDto> SendNotification(NotificationRequestDto notificationRequestDto, CancellationToken cancellationToken)
		{
			int userSenderId = _userContext.GetUserId();

            User userSenderNotification = await  _unitOfWork.UsersRepository.GetById(userSenderId);
			User userToSendNotification = await _unitOfWork.UsersRepository.GetUserbyEmail(notificationRequestDto.UserToSendNotification!);
            
			Notification notification = new Notification()
			{
				UserSender = userSenderNotification.Id,
				UserReceiver = userToSendNotification.Id,
				Title = "Tiene Una nueva Notificación",
				Type = notificationRequestDto.Type,
				Message = notificationRequestDto.Message,
				IsRead = false,
				PropertyId = notificationRequestDto.PropertyId,
			};

			await _unitOfWork.NotificationRepository.Create(notification, cancellationToken);
            await _unitOfWork.Complete(cancellationToken);

            //await _hubContext.Clients.User(userRecievingId.Id.ToString()).SendAsync("ReceiveNotification", notification.Message);

            NotificationResponseDto notificationResponseDto = notification.ToResponse();

            return notificationResponseDto;
        }

		
    }

}
