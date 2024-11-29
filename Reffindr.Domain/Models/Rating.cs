using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Domain.Models;

public class Rating : BaseModel
	{

		public int RatedByUserId { get; set; } 

		public int RatedUserId { get; set; } 

		public int RatingValue { get; set; }

		public string? Comment { get; set; }

		public virtual User? RatedBy { get; set; }
		public virtual User? RatedUser { get; set; }
	}
