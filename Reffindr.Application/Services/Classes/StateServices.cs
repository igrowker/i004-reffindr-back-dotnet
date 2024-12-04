using Reffindr.Application.Services.Interfaces;
using Reffindr.Domain.Models;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Response.Property;
using Reffindr.Shared.DTOs.Response.State;
using Reffindr.Application.Utilities.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reffindr.Application.Services.Classes
{
	public class StateServices : IStateServices
	{
		private readonly IUnitOfWork _unitOfWork;
		public StateServices(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<StateGetResponseDTO> GetStateForId(int id)
		{
			State state= await _unitOfWork.StateRepository.GetStatesById(id);
			return StateMappers.ToResponse(state);
		}

		public async Task<List<StateGetResponseDTO>> GetStates()
		{
			List<State>? states = await _unitOfWork.StateRepository.GetStates();

			List<StateGetResponseDTO>? statesdto = states!.Select(x => StateMappers.ToResponse(x)).ToList();
			return statesdto;
		}
	}
}
