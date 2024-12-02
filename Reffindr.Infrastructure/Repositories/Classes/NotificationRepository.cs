using Microsoft.EntityFrameworkCore;
using Reffindr.Domain.Models;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;
using Reffindr.Shared.DTOs.Pagination;
using Reffindr.Shared.IQueryableExtensions;

namespace Reffindr.Infrastructure.Repositories.Classes
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
	{
		public NotificationRepository(ApplicationDbContext dbContext) : base(dbContext)
		{

		}

        public async Task<List<Notification>> GetNotifications(int userId, PaginationDto paginationDto)
        {
            var recordsQueriable = _dbSet.AsQueryable();

            return await recordsQueriable.Paginate(paginationDto).Where(x => x.UserReceivingId == userId).ToListAsync();
        }
    }
}
