using Reffindr.Application.Services.Interfaces;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.UnitOfWork;

namespace Reffindr.Application.Services.Classes
{
	public class NotificationService : INotificationService
	{
		private readonly IUnitOfWork _unitOfWork;
		public NotificationService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;

		}
		public async Task AddNotificationToUser(Property property,int UserSenderId)
		{
			User User= await _unitOfWork.UsersRepository.GetById(property.OwnerId);

			Notification notification = new Notification()
			{
				UserReceivingId = property.OwnerId,
				Message ="Su propiedad fue publicada",
				Type = "Application",
				Read =false,
				UserSenderId = UserSenderId
			};
			//await _unitOfWork.UsersRepository.Update(property.OwnerId,);
		}

		public async Task SendNotificationAsync(Notification notification)
		{
			await Task.CompletedTask;
		}
	}
}
