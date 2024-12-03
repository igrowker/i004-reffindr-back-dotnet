﻿using Microsoft.EntityFrameworkCore.Storage;
using Reffindr.Infrastructure.Repositories.Classes;
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
	IUserOwnerInfoRepository UserOwnerInfoRepository { get; }
	IImageRepository ImageRepository { get; }
    IImageRepository ImageRepository { get; }
    IFavoriteRepository FavoriteRepository { get; }
    Task<int> Complete(CancellationToken cancellationToken);
	void Dispose();
	Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken);

}
