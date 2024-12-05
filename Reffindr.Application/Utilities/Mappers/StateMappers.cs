using Reffindr.Domain.Models;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Response.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reffindr.Application.Utilities.Mappers
{
	public static class StateMappers
	{
		public static StateGetResponseDTO ToResponse(this State state)
		{
			return new StateGetResponseDTO
			{
				Id = state.Id,
				StateName = state.StateName,
			};
		}
	}
}
