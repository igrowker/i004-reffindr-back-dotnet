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
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }


        /// <summary>
        /// Obtener aplicaciones asociadas a un usuario específico.
        /// </summary>
        /// <remarks>
        /// Este endpoint recupera una lista de aplicaciones asociadas a un usuario identificado por su ID.
        /// </remarks>
        /// <param name="userId">ID del usuario cuyas aplicaciones se desean obtener.</param>
        /// <returns>Devuelve una lista de aplicaciones asociadas al usuario.</returns>
        /// <response code="200">Si la operación es exitosa, devuelve las aplicaciones del usuario.</response>
        /// <response code="404">Si no se encuentran aplicaciones para el usuario o ocurre un error, devuelve un mensaje de error.</response>
        [HttpGet]
        [Route("{userId:int}")]
        public async Task<IActionResult> GetApplicationsByUserIdAsync(int userId)
        {
            var result = await _applicationService.GetApplicationsByUserIdAsync(userId);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result.Error });
            }

            return Ok(result.Value);
        }

        /// <summary>
        /// Registrar una nueva aplicación en el sistema.
        /// </summary>
        /// <remarks>
        /// Este endpoint permite registrar una nueva aplicación proporcionando los datos requeridos en el cuerpo de la solicitud.
        /// </remarks>
        /// <param name="applicationPostRequestDto">Objeto que contiene los datos necesarios para registrar la aplicación, como nombre, descripción y otros detalles.</param>
        /// <param name="cancellationToken">Token de cancelación para la operación asíncrona.</param>
        /// <returns>Devuelve el resultado del registro de la aplicación.</returns>
        /// <response code="200">Si el registro es exitoso, devuelve los detalles de la aplicación registrada.</response>
        /// <response code="400">Si los datos proporcionados son inválidos o hay un error, devuelve un mensaje con la descripción del problema.</response>
        [Route("PostApplication")]
        [HttpPost]
        public async Task<IActionResult> PostApplication(ApplicationPostRequestDto applicationPostRequestDto, CancellationToken cancellationToken)
        {

            Result<ApplicationPostResponseDto> result = await _applicationService.PostApplicationAsync(applicationPostRequestDto, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result.Error });
            }

            return Ok(result.Value);
        }
    }
}
