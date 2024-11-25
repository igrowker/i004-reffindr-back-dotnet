namespace Reffindr.Shared.DTOs.Response.Notification;

public class NotificationResponseDto
{
    public string? Message { get; set; }
    public string? Type { get; set; }
    public bool Read { get; set; }
    public int? UserSenderId { get; set; }
}
