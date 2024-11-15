using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reffindr.Domain.Models
{
	public class Notification : BaseModel
	{
		public int UserId { get; set; }

		public string? Message { get; set; }

		public string? Type { get; set; }

		public bool Read { get; set; }

		public User.User? User { get; set; }
	}
}
