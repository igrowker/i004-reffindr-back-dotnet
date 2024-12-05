using Reffindr.Domain.Models;
using Reffindr.Shared.DTOs.Response.Notification;

namespace Reffindr.Application.Utilities.Mappers;

public static class NotificationMappers
{


    public static NotificationResponseDto ToResponse(this Notification notification)
    {
        return new NotificationResponseDto
        {
            Message =  notification.Message,
            Read = notification.Read,
            Type = notification.Type.ToString(),
            UserSenderId = notification.UserSenderId,
            PropertyId = notification.PropertyId
        };
    }

    
}
