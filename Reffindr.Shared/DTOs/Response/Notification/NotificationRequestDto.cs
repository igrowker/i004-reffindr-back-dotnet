using Reffindr.Shared.Enum;

namespace Reffindr.Shared.DTOs.Response.Notification;

public class NotificationRequestDto
{
    public string? Message { get; set; }
    public string? UserToSendNotification { get; set; }
    public NotificationType? Type { get; set; }
    public int? PropertyId { get; set; }



}
