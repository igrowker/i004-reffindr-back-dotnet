using Reffindr.Shared.DTOs.Response.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reffindr.Application.Services.Interfaces
{
	public interface IStateServices
	{
		Task<List<StateGetResponseDTO>> GetStates();
		Task<StateGetResponseDTO> GetStateForId(int id);
	}
}
