﻿using Reffindr.Domain.Models.UserModels;
using Reffindr.Shared.Enum;

namespace Reffindr.Domain.Models;

public class Notification : BaseModel
{
	public int? UserReceivingId { get; set; }

	public string? Message { get; set; }

	public NotificationType? Type { get; set; }

	public int PropertyId { get; set; }

	public bool Read { get; set; }

	public virtual Property? Property { get; set; }

	public virtual User? UserReceiving { get; set; }

	public int? UserSenderId { get; set; }

}
