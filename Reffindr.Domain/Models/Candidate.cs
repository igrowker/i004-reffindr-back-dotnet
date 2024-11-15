

namespace Reffindr.Domain.Models
{
	public class Candidate : BaseModel
	{
		public int AplicationId { get; set; }
		public bool SelectedByTenant { get; set; }

		public Aplications? Aplication { get; set; }

	}
}
