using Reffindr.Shared.DTOs.Pagination;
using Reffindr.Shared.DTOs.Response.Notification;
using Reffindr.Shared.Enum;

namespace Reffindr.Application.Services.Interfaces
{
    public interface INotificationService
	{
		Task<NotificationResponseDto> SendNotification( NotificationRequestDto notificationRequestDto, CancellationToken cancellationToken);
        Task<List<NotificationResponseDto>> GetNotificationsAsync(PaginationDto paginationDto);
    }
}
