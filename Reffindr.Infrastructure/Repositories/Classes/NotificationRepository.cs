using Microsoft.EntityFrameworkCore;
using Reffindr.Domain.Models;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.Repositories.Interfaces;
using Reffindr.Shared.DTOs.Pagination;
using Reffindr.Shared.Enum;
using Reffindr.Shared.IQueryableExtensions;

namespace Reffindr.Infrastructure.Repositories.Classes;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    private readonly IUserContext _userContext;

    public NotificationRepository(ApplicationDbContext dbContext, IUserContext userContext) : base(dbContext)
    {
        _userContext = userContext;
    }

    public async Task<List<Notification>> GetNotifications(PaginationDto paginationDto)
    {
        int userCurrentId = _userContext.GetUserId();

        var recordsQueriable = _dbSet.AsQueryable();

        return await recordsQueriable.Paginate(paginationDto).Where(x => x.UserReceiver == userCurrentId).ToListAsync();
    }

    public async Task<Notification> GetNotificationByOwnerPropertyId(int propertyId)
    {
        var foundnNotification = await  _dbSet.Where(x => x.PropertyId == propertyId).OrderByDescending(x => x.CreatedAt).FirstOrDefaultAsync();

        return foundnNotification!;
    }

    public async Task<List<Notification>> GetNotificationsByType(NotificationType NotificationType, CancellationToken cancellationToken)
    {
        int userCurrentId = _userContext.GetUserId();

        List<Notification> notifications = await _dbSet.Where(x => x.UserReceiver == userCurrentId && x.Type == NotificationType).ToListAsync();

        return notifications;
    }


}