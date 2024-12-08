using Reffindr.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reffindr.Infrastructure.Repositories.Interfaces
{
	public interface IStateRepository : IGenericRepository<State>
    {
		Task<List<State>?> GetStates();
		Task<State> GetStatesById(int id);
	}
}
