
namespace Reffindr.Domain.Models
{
	public class Aplications : BaseModel
	{
		public int PropertyId { get; set; }
		public int UserId { get; set; }
		public string? Status { get; set; }
		public Property? Property { get; set; }
		public User.User? User { get; set; }
	}
}
