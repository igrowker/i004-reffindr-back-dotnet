using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Domain.Models;

public class Notification : BaseModel
	{
		public int UserId { get; set; }

		public string? Message { get; set; }

		public string? Type { get; set; }

		public bool Read { get; set; }

		public virtual User? User { get; set; }
	}
