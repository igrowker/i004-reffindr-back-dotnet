using Reffindr.Shared.DTOs.Pagination;
using Reffindr.Shared.DTOs.Response.Notification;
using Reffindr.Shared.Enum;

namespace Reffindr.Application.Services.Interfaces
{
    public interface INotificationService
	{
		Task<NotificationResponseDto> AddNotificationToUser(string userReceivingEmail, int PropertyId, NotificationType status, CancellationToken cancellationToken);
		Task<NotificationResponseDto> ConfirmPropertyfromNotification(int propertyId, CancellationToken cancellationToken);
        Task<List<NotificationResponseDto>> GetNotificationsAsync(PaginationDto paginationDto);
    }
}
