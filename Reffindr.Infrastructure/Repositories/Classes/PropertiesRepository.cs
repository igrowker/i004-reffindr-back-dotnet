using Microsoft.EntityFrameworkCore;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;
using Reffindr.Shared.DTOs.Filter;
using Reffindr.Shared.DTOs.Response.Property;
using System.Threading;
using Property = Reffindr.Domain.Models.Property;

namespace Reffindr.Infrastructure.Repositories.Classes;

public class PropertiesRepository : GenericRepository<Property>, IPropertiesRepository
{
    public PropertiesRepository(ApplicationDbContext options) : base(options)
    {
    }

    public async Task<List<Property>?> GetOwnerProperties(int ownerUserId)
    {
        List<Property>? ownerProperties = await _dbSet
            .Include(x => x.Images)
            .Where(x => x.OwnerId == ownerUserId)
            .ToListAsync();
        return ownerProperties;
    }

    public async Task<List<Property>?> GetTenantAnnounce(int tenantUserId)
    {
        List<Property>? ownerProperties = await _dbSet
            .Include(x => x.Images)
            .Where(x => x.TenantId == tenantUserId)
            .ToListAsync();
        return ownerProperties;
    }

    public async Task<Property?> GetByIdWithRequirementsAsync(int propertyId)
    {
        Property? property = await _dbSet
            .Include(p => p.Requirement)
            .FirstOrDefaultAsync(p => p.Id == propertyId && !p.IsDeleted);

        return property;
    }
	public async Task<Property?> GetByIdWithIncludeAsync(int propertyId)
	{
		Property? property = await _dbSet
			.Include(p => p.Requirement)
			.Include(p => p.Images)
            .Include(p=>p.Application)
			.FirstOrDefaultAsync(p => p.Id == propertyId);

		return property;
	}


	public async Task<Tuple<int?, int?>> GetOwnerIdAndTenantId(int propertyId)
    {
        // Obtener solo el id del propietario y el inquilino de la propiedad
        var ids = await _dbSet
            .Where(p => p.Id == propertyId)
            .Select(p => new { p.OwnerId, p.TenantId })
            .FirstOrDefaultAsync();

        return new Tuple<int?, int?>(ids?.OwnerId, ids?.TenantId);
    }

    public async Task<List<Property>> GetPropertiesAsync(PropertyFilterDto filter)
    {
        var query = _dbSet
            .Include(p => p.Country)
            .Include(p => p.State)
            .Include(p => p.Requirement)
            .Include(p => p.Images)
            .Where(p => p.IsDeleted == false);

        // Aplicar filtros basados en los parámetros proporcionados
        if (filter.CountryId.HasValue)
            query = query.Where(p => p.CountryId == filter.CountryId.Value);

        if (filter.StateId.HasValue)
            query = query.Where(p => p.StateId == filter.StateId.Value);

        if (!string.IsNullOrEmpty(filter.Title))
            query = query.Where(p => p.Title.Contains(filter.Title));

        // Comparar con el precio
        if (filter.PriceMin.HasValue)
            query = query.Where(p => p.Price >= filter.PriceMin.Value);

        if (filter.PriceMax.HasValue)
            query = query.Where(p => p.Price <= filter.PriceMax.Value);

        // Aplicar filtros basados en los requisitos
        if (filter.IsWorking.HasValue)
            query = query.Where(p => p.Requirement!.IsWorking == filter.IsWorking.Value);

        if (filter.HasWarranty.HasValue)
            query = query.Where(p => p.Requirement!.HasWarranty == filter.HasWarranty.Value);

        if (filter.RangeSalaryMin.HasValue)
            query = query.Where(p => p.Requirement!.RangeSalary >= filter.RangeSalaryMin.Value);

        if (filter.RangeSalaryMax.HasValue)
            query = query.Where(p => p.Requirement!.RangeSalary <= filter.RangeSalaryMax.Value);

        // Obtener la información del perfil del usuario
        //var tenantInfo = await _userTenantInfoRepository.GetById(userId);

        //if (tenantInfo != null)
        //{
        //    // Aplicar filtros adicionales basados en el perfil del usuario
        //    if (tenantInfo.IsWorking)
        //        query = query.Where(p => p.Requirement!.IsWorking == true);

        //    if (tenantInfo.HasWarranty)
        //        query = query.Where(p => p.Requirement!.HasWarranty == true);

        //    //if (tenantInfo.RangeSalary > 0)
        //    //    query = query.Where(p => p.Requirement!.RangeSalary <= tenantInfo.RangeSalary);
        //}

        return await query.ToListAsync();
    }

    public IQueryable<Property> GetPropertiesAsQueryable()
    {
        return _dbSet.AsQueryable();
    }
}
