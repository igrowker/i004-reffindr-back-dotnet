using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reffindr.Domain.Models
{
	public class Rating : BaseModel
	{

		public int RatedById { get; set; } 

		public int RatedUserId { get; set; } 

		public int RatingValue { get; set; }

		public string? Comment { get; set; }

	}
}
