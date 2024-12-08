using Reffindr.Domain.Models;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reffindr.Infrastructure.Repositories.Classes
{
	public class RequirementRepository : GenericRepository<Requirement>, IRequirement
	{
		public RequirementRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}

