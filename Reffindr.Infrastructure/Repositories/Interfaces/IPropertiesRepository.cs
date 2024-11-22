using System.Threading.Tasks;
using Property = Reffindr.Domain.Models.Property;

namespace Reffindr.Infrastructure.Repositories.Interfaces;

public interface IPropertiesRepository : IGenericRepository<Property>
{
    Task<Property?> GetByIdWithRequirementsAsync(int propertyId);
}
