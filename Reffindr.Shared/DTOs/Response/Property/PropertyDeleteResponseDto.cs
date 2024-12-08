using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Reffindr.Shared.DTOs.Response.Property
{
	public class PropertyDeleteResponseDto
	{
		public int PropertyId { get; set; }
		public bool PropertyMatchesOwner { get; set; }
	}
}
