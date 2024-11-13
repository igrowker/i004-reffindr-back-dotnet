using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Reffindr.Infrastructure.Data;

namespace Reffindr.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork
        (
            ApplicationDbContext dbContext
        )
    {
        _dbContext = dbContext;
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
