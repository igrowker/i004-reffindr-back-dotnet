﻿using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;

namespace Reffindr.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public IAuthRepository AuthRepository { get; }
    public IUsersRepository UsersRepository { get; }
    public IPropertiesRepository PropertiesRepository { get; }
    public IApplicationRepository ApplicationRepository { get; }
    public ICandidateRepository CandidateRepository { get; }
    public INotificationRepository NotificationRepository { get; }
    public IUserTenantInfoRepository UserTenantInfoRepository { get; }
    public IUserOwnerInfoRepository UserOwnerInfoRepository { get; }


    public UnitOfWork
        (
            ApplicationDbContext dbContext,
            IAuthRepository authRepository,
            IUsersRepository usersRepository,
            IPropertiesRepository propertiesRepository,
            IApplicationRepository applicationRepository,
            ICandidateRepository candidateRepository,
			INotificationRepository notificationRepository,
            IUserTenantInfoRepository userTenantInfoRepository

		)
    {
        _dbContext = dbContext;
        AuthRepository = authRepository;
        UsersRepository = usersRepository;
        PropertiesRepository = propertiesRepository;
        ApplicationRepository = applicationRepository;
        CandidateRepository = candidateRepository;
        NotificationRepository = notificationRepository;
        UserTenantInfoRepository = userTenantInfoRepository;
    }
    public async Task<int> Complete(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public async Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken)
    {
        return await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }
}
