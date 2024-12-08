using Microsoft.EntityFrameworkCore.Storage;
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
    public IImageRepository ImageRepository { get; }
    public IFavoriteRepository FavoriteRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public IGenreRepository GenreRepository { get; }
    public ISalaryRepository SalaryRepository { get; }
    public IStateRepository StateRepository { get; }
    public ICountryRepository CountryRepository { get; }
    public IRequirement RequimentsRepository { get; }



	public UnitOfWork
        (
            ApplicationDbContext dbContext,
            IAuthRepository authRepository,
            IUsersRepository usersRepository,
            IPropertiesRepository propertiesRepository,
            IApplicationRepository applicationRepository,
            ICandidateRepository candidateRepository,
            INotificationRepository notificationRepository,
            IUserTenantInfoRepository userTenantInfoRepository,
            IImageRepository imageRepository,
            IUserOwnerInfoRepository userOwnerInfoRepository,
            IFavoriteRepository favoriteRepository,
            IRoleRepository roleRepository,
            IGenreRepository genreRepository,
            ISalaryRepository salaryRepository,
            IStateRepository stateRepository,
            IRequirement requerimentsRepository,
            ICountryRepository countryRepository

            )

    {
        _dbContext = dbContext;
        GenreRepository = genreRepository;
        SalaryRepository = salaryRepository;
        SalaryRepository = salaryRepository;
        AuthRepository = authRepository;
        UsersRepository = usersRepository;
        PropertiesRepository = propertiesRepository;
        ApplicationRepository = applicationRepository;
        CandidateRepository = candidateRepository;
        NotificationRepository = notificationRepository;
        UserTenantInfoRepository = userTenantInfoRepository;
        ImageRepository = imageRepository;
        UserOwnerInfoRepository = userOwnerInfoRepository;
        FavoriteRepository = favoriteRepository;
        RoleRepository = roleRepository;
        GenreRepository = genreRepository;
        StateRepository = stateRepository;
        CountryRepository = countryRepository;
        RequimentsRepository = requerimentsRepository;
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
