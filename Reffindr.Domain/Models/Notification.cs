using Reffindr.Domain.Models.UserModels;
using Reffindr.Shared.Enum;

namespace Reffindr.Domain.Models;

public class Notification : BaseModel
{
	public int? UserSender { get; set; }
	public int? UserReceiver { get; set; }
    public NotificationType? Type { get; set; }
    public string? Message { get; set; }
    public string? Title { get; set; }

	public int? PropertyId { get; set; }

	public bool IsRead { get; set; }

	public virtual Property? Property { get; set; }

	public virtual User? User { get; set; }


}
