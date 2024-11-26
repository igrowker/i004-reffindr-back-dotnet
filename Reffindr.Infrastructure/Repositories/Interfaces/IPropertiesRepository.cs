using Reffindr.Shared.DTOs.Filter;
using Property = Reffindr.Domain.Models.Property;

namespace Reffindr.Infrastructure.Repositories.Interfaces;

public interface IPropertiesRepository : IGenericRepository<Property>
{
    Task<IEnumerable<Property>> GetPropertiesAsync(PropertyFilterDto filter, int userId);
    Task<Tuple<int?, int?>> GetOwnerIdAndTenantId(int propertyId);
    Task<Property?> GetByIdWithRequirementsAsync(int propertyId);
}
