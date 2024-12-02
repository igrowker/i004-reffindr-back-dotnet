using Reffindr.Domain.Models;
using Reffindr.Shared.DTOs.Pagination;

namespace Reffindr.Infrastructure.Repositories.Interfaces
{
	public interface INotificationRepository : IGenericRepository<Notification>
	{
        Task<List<Notification>> GetNotifications(int userId, PaginationDto paginationDto);

    }
}
