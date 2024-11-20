using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;
using Property = Reffindr.Domain.Models.Property;

namespace Reffindr.Infrastructure.Repositories.Classes;

public class PropertiesRepository : GenericRepository<Property> , IPropertiesRepository
{
    public PropertiesRepository(ApplicationDbContext options) : base(options)
    {
        
    }

}
