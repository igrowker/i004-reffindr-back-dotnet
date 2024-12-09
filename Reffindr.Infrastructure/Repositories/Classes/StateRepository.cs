using Microsoft.EntityFrameworkCore;
using Reffindr.Domain.Models;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;
using Reffindr.Shared.DTOs.Response.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reffindr.Infrastructure.Repositories.Classes
{
	public class StateRepository : GenericRepository<State>, IStateRepository
	{
		public StateRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<List<State>?> GetStates()
		{
			List<State>? states = await _dbSet.ToListAsync();
			return states;
		}

		public async Task<State> GetStatesById(int id)
		{
			State? state = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
			return state!;
		}

	}
}
