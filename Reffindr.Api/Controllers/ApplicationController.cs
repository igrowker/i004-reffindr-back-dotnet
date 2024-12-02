using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Shared.DTOs.Request.Application;
using Reffindr.Shared.DTOs.Response.Application;
using Reffindr.Shared.Result;

namespace Reffindr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("User")]
        public async Task<IActionResult> GetApplicationsByUserIdAsync()
        {
            var result = await _applicationService.GetApplicationsByUserIdAsync();

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result.Error });
            }

            return Ok(result.Value);
        }

        [HttpGet("Property/{propertyId}")]
        public async Task<IActionResult> GetApplicationsByPropertyIdAsync(int propertyId)
        {
            List<ApplicationGetResponseDto> applications = await _applicationService.GetApplicationsByPropertyIdAsync(propertyId);

            return Ok(applications);
        }

		[HttpGet("SelectedCandidates/{propertyId}")]
		public async Task<IActionResult> GetApplicationsSelectedCandidatesAsync(int propertyId)
		{
			List<ApplicationGetResponseDto> applications = await _applicationService.GetApplicationsSelectedCandidatesAsync(propertyId);

			return Ok(applications);
		}

		[HttpPost]
        [Route("PostApplication")]
        public async Task<IActionResult> PostApplication(ApplicationPostRequestDto applicationPostRequestDto, CancellationToken cancellationToken)
        {

            Result<ApplicationPostResponseDto> result = await _applicationService.PostApplicationAsync(applicationPostRequestDto, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result.Error });
            }

            return Ok(result.Value);
        }


        /// <summary>
        /// Actualiza el selectedByTenant del candidato a true si el inquilino lo selecciona
        /// </summary>
        /// <remarks>
        /// Este endpoint permite actualizar el selectedByTenant del candidato de  la entidad application
        /// Se requiere autorización para acceder a este recurso.
        /// </remarks>
        /// <param name="candidateUserId">
        /// </param>
        /// <param name="propertyId">
        /// </param>
        /// <param name="cancellationToken">
        /// </param>
        /// <returns>
        /// Si ocurre un error, se devolverá un código de estado HTTP correspondiente.
        /// </returns>
        /// <response code="200">El usuario fue actualizado exitosamente.</response>
        /// <response code="400">El cuerpo de la solicitud no es válido.</response>
        /// <response code="401">El usuario no está autorizado para realizar esta acción.</response>
        /// <response code="404">No se encontró el usuario especificado.</response>
        /// <response code="500">Ocurrió un error interno en el servidor.</response>
        [HttpPut]
        [Route("PutSelectApplicationCandidates")]
        public async Task<IActionResult> PutSelectCandidates(int candidateUserId, int propertyId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.PutSelectCandidatesAsync(candidateUserId, propertyId, cancellationToken);
            return Ok((result));
        }

    


    }
}
