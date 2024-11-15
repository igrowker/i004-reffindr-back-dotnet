
namespace Reffindr.Domain.Models;

public class State : BaseModel
{
	public string? StateName { get; set; }

	public int CountryId { get; set; }

	#region Navigation Properties
	public virtual Country? Country { get; set; }
	#endregion
}
