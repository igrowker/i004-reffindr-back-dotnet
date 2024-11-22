using Microsoft.EntityFrameworkCore;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;
using System.Threading;
using Property = Reffindr.Domain.Models.Property;

namespace Reffindr.Infrastructure.Repositories.Classes;

public class PropertiesRepository : GenericRepository<Property> , IPropertiesRepository
{
    public PropertiesRepository(ApplicationDbContext options) : base(options)
    {
        
    }

    public async Task<Property?> GetByIdWithRequirementsAsync(int propertyId)
    {
        return await _dbSet
        .Include(p => p.Requirement)
        .FirstOrDefaultAsync(p => p.Id == propertyId && !p.IsDeleted);
    }
}
