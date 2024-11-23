using Reffindr.Shared.DTOs.Pagination;
using Reffindr.Shared.DTOs.Response.Notification;
using Reffindr.Shared.Enum;

namespace Reffindr.Application.Services.Interfaces
{
    public interface INotificationService
	{
        Task<List<NotificationResponseDto>> GetNotificationsAsync(PaginationDto paginationDto);

        Task AddNotificationToUser(string userReceivingEmail, NotificationType status, CancellationToken cancellationToken);

    }
}
