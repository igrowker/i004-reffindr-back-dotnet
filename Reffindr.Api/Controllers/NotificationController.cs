using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Shared.DTOs.Pagination;
using Reffindr.Shared.DTOs.Response.Notification;

namespace Reffindr.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;

		public NotificationController(INotificationService notificationService)
		{

			_notificationService = notificationService;
		}

        /// <summary>
        /// Confirma una propiedad desde una notificación.
        /// </summary>
        /// <remarks>
        /// Este endpoint permite confirmar una propiedad específica basada en una notificación recibida. 
        /// Se requiere autorización para acceder a este recurso.
        /// </remarks>
        /// <param name="propertyId">El identificador único de la propiedad que se desea confirmar.</param>
        /// <returns>
        /// Devuelve un código de estado HTTP 200 (OK) si la operación se realizó con éxito. 
        /// Si ocurre un error, devolverá un código de error apropiado.
        /// </returns>
        /// <response code="200">La propiedad fue confirmada exitosamente.</response>
        /// <response code="400">El identificador de la propiedad no es válido.</response>
        /// <response code="401">El usuario no está autorizado para realizar esta acción.</response>
        /// <response code="404">No se encontró la propiedad especificada.</response>
        /// <response code="500">Ocurrió un error interno en el servidor.</response>
        [Authorize]
		[HttpPut]
		[Route("ConfirmProperty/{propertyId:int}")]

		public async Task<IActionResult> ConfirmPropertyFromNotification(int propertyId)
		{
			await _notificationService.ConfirmPropertyfromNotification(propertyId);
			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> GetUserNotifications([FromQuery] PaginationDto paginationDto)
		{
			List<NotificationResponseDto> notificationsResponse = await _notificationService.GetNotificationsAsync(paginationDto);
			return Ok(notificationsResponse);
		}
	}
}

