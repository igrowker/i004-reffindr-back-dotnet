using Reffindr.Domain.Models;
using Reffindr.Shared.DTOs.Pagination;
using Reffindr.Shared.Enum;

namespace Reffindr.Infrastructure.Repositories.Interfaces
{
	public interface INotificationRepository : IGenericRepository<Notification>
	{
        Task<List<Notification>> GetNotifications( PaginationDto paginationDto);
        Task<Notification> GetNotificationByOwnerPropertyId(int propertyId);
        Task<List<Notification>> GetNotificationsByType(NotificationType NotificationType,
            CancellationToken cancellationToken);
    }
}
