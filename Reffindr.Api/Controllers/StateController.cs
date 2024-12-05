using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Shared.DTOs.Response.State;

namespace Reffindr.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StateController : ControllerBase
	{
		private readonly IStateServices _stateServices;
		public StateController(IStateServices stateServices)
		{
			_stateServices = stateServices;
		}

		[HttpGet("Get-States")]
		public async Task<IActionResult> GetStates()
		{
			List<StateGetResponseDTO> states =await _stateServices.GetStates();

			return Ok(states);
		}
	}
}
