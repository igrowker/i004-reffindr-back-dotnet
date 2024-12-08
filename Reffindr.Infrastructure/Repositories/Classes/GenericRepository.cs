using Microsoft.EntityFrameworkCore;
using Reffindr.Domain.Models;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;
using Reffindr.Shared.DTOs.Pagination;
using Reffindr.Shared.IQueryableExtensions;

namespace Reffindr.Infrastructure.Repositories.Classes;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
{
    protected DbSet<T> _dbSet;
    protected DbContext _dbContext;
    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
        _dbContext = dbContext;
    }

    public virtual async Task<List<T>> GetAllWithPagination(PaginationDto paginationDto)
    {
        var recordsQueriable = _dbSet.AsQueryable();

        return await recordsQueriable.Paginate(paginationDto).ToListAsync();
    }

    public async Task<T> GetById(int? id)
    {
        var recordDb = await _dbSet.FindAsync(id);
        return recordDb!;
    }

    public async Task<T> Create(T model, CancellationToken cancellationToken)
    {
        model.CreatedAt = DateTime.UtcNow;
        await _dbSet.AddAsync(model, cancellationToken);
        return model;
    }
    public virtual async Task<T> Update(int id, T model)
    {
        var existingData = await _dbSet.FindAsync(id);

        if (existingData is null) throw new KeyNotFoundException("No se encontro el modelo");

        model.UpdatedAt = DateTime.UtcNow;

        _dbContext.Entry(existingData).CurrentValues.SetValues(model);

        return existingData;
    }

    public virtual async Task<List<T>> UpdateList(List<T> models)
    {
        foreach (var model in models)
        {
            var existingData = await _dbSet.FindAsync(model.Id);

            if (existingData == null) throw new KeyNotFoundException($"No se encontró el modelo con ID {model.Id}");

            model.UpdatedAt = DateTime.UtcNow;

            _dbContext.Entry(existingData).CurrentValues.SetValues(model);
        }

        return models;
    }


    public async Task<T> SoftDelete(int id)
    {
        var recordToDelete = await GetById(id);

        if (recordToDelete is null) throw new Exception("El registro no se encontro");

        recordToDelete.IsDeleted = true;
        recordToDelete.UpdatedAt = DateTime.UtcNow;

        return recordToDelete;
    }

    public async Task<T> Delete (int id)
    {
        var recordToDelete = await GetById(id);

		if (recordToDelete is null) throw new Exception("El registro no se encontro");

        _dbContext.Remove(recordToDelete);

        return recordToDelete;
	}
}

