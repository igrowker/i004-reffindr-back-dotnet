using Reffindr.Shared.Enum;

namespace Reffindr.Shared.DTOs.Response.Notification;

public class NotificationResponseDto
{
    public string? Title { get; set; }
    public string? Message { get; set; }
    public NotificationType? Type { get; set; }
    public bool Read { get; set; }
    public int? UserSenderId { get; set; }
    public int? UserReceiver { get; set; }
    public int? PropertyId { get; set; }
}
