using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Response.Property;

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

		[Authorize]
		[HttpPut]
		[Route("ConfirmProperty/{propertyId:int}")]

		public async Task<IActionResult> ConfirmPropertyFromNotification(int propertyId)
		{
			await _notificationService.ConfirmPropertyfromNotification(propertyId);
			return Ok();
		}
	}

}

