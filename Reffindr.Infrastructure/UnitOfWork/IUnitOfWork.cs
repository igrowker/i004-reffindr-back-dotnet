using Microsoft.EntityFrameworkCore.Storage;
using Reffindr.Infrastructure.Repositories.Interfaces;

namespace Reffindr.Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
	IUsersRepository UsersRepository { get; }
	IAuthRepository AuthRepository { get; }
	IPropertiesRepository PropertiesRepository { get; }
	IApplicationRepository ApplicationRepository { get; }
	ICandidateRepository CandidateRepository { get; }
	INotificationRepository NotificationRepository { get; }
	IUserTenantInfoRepository UserTenantInfoRepository { get; }
	Task<int> Complete(CancellationToken cancellationToken);
	void Dispose();
	Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken);

}
