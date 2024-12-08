using Reffindr.Shared.DTOs.Filter;
using Reffindr.Shared.DTOs.Response.Property;
using Property = Reffindr.Domain.Models.Property;

namespace Reffindr.Infrastructure.Repositories.Interfaces;

public interface IPropertiesRepository : IGenericRepository<Property>
{
    Task<List<Property>> GetPropertiesAsync(PropertyFilterDto filter);
    Task<Tuple<int?, int?>> GetOwnerIdAndTenantId(int propertyId);
    Task<Property?> GetByIdWithRequirementsAsync(int propertyId);
    Task<List<Property>?> GetOwnerProperties(int ownerUserId);
    Task<Property?> GetByIdWithIncludeAsync(int propertyId);
	IQueryable<Property> GetPropertiesAsQueryable();
    Task<List<Property>?> GetTenantAnnounce(int tenantUserId);
}
