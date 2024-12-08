using Reffindr.Domain.Models;
using Reffindr.Shared.DTOs.Response.Notification;

namespace Reffindr.Application.Utilities.Mappers;

public static class NotificationMappers
{
    public static NotificationResponseDto ToResponse(this Notification notification)
    {
        return new NotificationResponseDto
        {
            UserSenderId = notification.UserSender,
            UserReceiver = notification.UserReceiver,
            Title = notification.Title,
            Message =  notification.Message,
            PropertyId = notification.PropertyId
        };
    }

    
}
