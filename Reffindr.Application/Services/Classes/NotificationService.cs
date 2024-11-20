using Reffindr.Application.Services.Interfaces;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.Enum;

namespace Reffindr.Application.Services.Classes
{
	public class NotificationService : INotificationService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserContext _userContext;

		public NotificationService(IUnitOfWork unitOfWork , IUserContext userContext)
		{
			_unitOfWork = unitOfWork;
			_userContext = userContext;
		}
		public async Task AddNotificationToUser(string userRecievingEmail, NotificationType Type, CancellationToken cancellationToken)
		{
			int userSenderId = _userContext.GetUserId();
			var userRecievingId = await _unitOfWork.UsersRepository.GetUserbyEmail(userRecievingEmail);
	

			Notification notification = new Notification()
			{
				UserReceivingId = userRecievingId.Id,
				Message = $"Tiene nueva notificacion de tipo {Type}",
				Type = Type.ToString(),
				Read = false,
				UserSenderId = userSenderId
			};
			await _unitOfWork.NotificationRepository.Create(notification, cancellationToken);
		}
	}
}
