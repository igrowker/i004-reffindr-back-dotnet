using Reffindr.Application.Services.Interfaces;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.Enum;

namespace Reffindr.Application.Services.Classes
{
	public class NotificationService : INotificationService
	{
		private readonly IUnitOfWork _unitOfWork;
		public NotificationService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			//falta implementar email ...falta implementar result
		}
		public async Task AddNotificationToUser( int UserReceiving, int UserSenderId, NotificationType Type, CancellationToken cancellationToken)
		{

			Notification notification = new Notification()
			{
				UserReceivingId = UserReceiving,
				Message = $"Tiene nueva notificacion de tipo {Type}",
				Type = Type.ToString(),
				Read = false,
				UserSenderId = UserSenderId
			};
			await _unitOfWork.NotificationRepository.Create(notification, cancellationToken);
		}
	}
}
