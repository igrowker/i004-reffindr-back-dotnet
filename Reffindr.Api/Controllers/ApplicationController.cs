using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Domain.Models;
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

        /// <summary>
        /// Obtiene las aplicaciones hechas por del usuario actual
        /// </summary>
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

        /// <summary>
        /// Obtiene las aplicaciones de una propiedad
        /// </summary>
        [HttpGet("Property/{propertyId}")]
        public async Task<IActionResult> GetApplicationsByPropertyIdAsync(int propertyId)
        {
            List<ApplicationsWithUserGetResponseDto> applications = await _applicationService.GetApplicationsByPropertyIdAsync(propertyId);

            return Ok(applications);
        }

        /// <summary>
        /// Obtiene el candidato seleccionado por el tenant saliente
        /// </summary>
        [HttpGet("SelectedCandidates/{propertyId}")]
		public async Task<IActionResult> GetApplicationsSelectedCandidatesAsync(int propertyId)
		{
			List<ApplicationGetResponseDto> applications = await _applicationService.GetApplicationsSelectedCandidatesAsync(propertyId);

			return Ok(applications);
		}

        /// <summary>
        /// Usuario inquilino entrante aplica a una propiedad y envia notificacion al usuario inquilino saliente
        /// </summary>
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
        [HttpPut]
        [Route("PutSelectApplicationCandidates")]
        public async Task<IActionResult> PutSelectCandidates(int candidateUserId, int propertyId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.PutSelectCandidatesAsync(candidateUserId, propertyId, cancellationToken);
            return Ok((result));
        }

        /// <summary>
        /// Selecciona a un inquilo
        /// </summary>
        [HttpPut("PutSelectCandidate")]
        public async Task<IActionResult> PutSelectNewTenant(int userId, CancellationToken cancellationToken)
        {
            ApplicationModel selectedCandidateResponse = await _applicationService.PutSelectNewTenantAsync(userId, cancellationToken);

            return Ok(selectedCandidateResponse);
        }
    }
}
