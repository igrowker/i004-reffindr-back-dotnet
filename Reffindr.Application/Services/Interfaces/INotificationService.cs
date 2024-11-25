using Reffindr.Shared.DTOs.Pagination;
using Reffindr.Shared.DTOs.Response.Notification;
using Reffindr.Shared.Enum;

namespace Reffindr.Application.Services.Interfaces
{
    public interface INotificationService
	{
		Task AddNotificationToUser(string userReceivingEmail, int PropertyId, NotificationType status, CancellationToken cancellationToken);
		Task ConfirmPropertyfromNotification(int propertyId);
        Task<List<NotificationResponseDto>> GetNotificationsAsync(PaginationDto paginationDto);
    }
}
