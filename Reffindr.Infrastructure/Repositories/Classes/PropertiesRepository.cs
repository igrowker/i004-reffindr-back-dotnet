﻿using Microsoft.EntityFrameworkCore;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;
using Reffindr.Shared.DTOs.Filter;
using System.Threading;
using Property = Reffindr.Domain.Models.Property;

namespace Reffindr.Infrastructure.Repositories.Classes;

public class PropertiesRepository : GenericRepository<Property>, IPropertiesRepository
{
    private readonly IUserTenantInfoRepository _userTenantInfoRepository;
    public PropertiesRepository(ApplicationDbContext options, IUserTenantInfoRepository userTenantInfoRepository) : base(options)
    {
        _userTenantInfoRepository = userTenantInfoRepository;
    }

    public async Task<List<Property>?> GetOwnerProperties(int ownerUserId)
    {
        List<Property>? ownerProperties = await _dbSet.Where(x => x.OwnerId == ownerUserId).ToListAsync();
        return ownerProperties;
    }

    public async Task<Property?> GetByIdWithRequirementsAsync(int propertyId)
    {
        Property? property = await _dbSet
            .Include(p => p.Requirement)
            .FirstOrDefaultAsync(p => p.Id == propertyId && !p.IsDeleted);

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

    public async Task<IEnumerable<Property>> GetPropertiesAsync(PropertyFilterDto filter, int userId)
    {
        var query = _dbSet
            .Include(p => p.Country)
            .Include(p => p.State)
            .Include(p => p.Requirement)
            .Where(p => !p.IsDeleted);

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
        var tenantInfo = await _userTenantInfoRepository.GetById(userId);

        if (tenantInfo != null)
        {
            // Aplicar filtros adicionales basados en el perfil del usuario
            if (tenantInfo.IsWorking)
                query = query.Where(p => p.Requirement!.IsWorking == true);

            if (tenantInfo.HasWarranty)
                query = query.Where(p => p.Requirement!.HasWarranty == true);

            if (tenantInfo.RangeSalary > 0)
                query = query.Where(p => p.Requirement!.RangeSalary <= tenantInfo.RangeSalary);
        }

        // Ejecutar la consulta y devolver los resultados
        return await query.ToListAsync();
    }
}
