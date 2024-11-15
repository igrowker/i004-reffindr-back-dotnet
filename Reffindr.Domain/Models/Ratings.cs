namespace Reffindr.Domain.Models;

public class Rating : BaseModel
	{

		public int RatedById { get; set; } 

		public int RatedUserId { get; set; } 

		public int RatingValue { get; set; }

		public string? Comment { get; set; }

	}
