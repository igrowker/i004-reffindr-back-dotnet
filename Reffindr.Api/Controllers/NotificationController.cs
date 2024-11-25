using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Response.Property;
using Reffindr.Shared.DTOs.Pagination;
using Reffindr.Shared.DTOs.Response.Notification;

namespace Reffindr.Api.Controllers
{
namespace Reffindr.Api.Controllers;

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
    [HttpGet]
    public async Task<IActionResult> GetUserNotifications([FromQuery] PaginationDto paginationDto)
    {
			await _notificationService.ConfirmPropertyfromNotification(propertyId);
			return Ok();
		}
	}
        List<NotificationResponseDto> notificationsResponse = await _notificationService.GetNotificationsAsync(paginationDto);

        return Ok(notificationsResponse);
    }
}

