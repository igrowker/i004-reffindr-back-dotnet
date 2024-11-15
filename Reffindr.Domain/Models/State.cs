
namespace Reffindr.Domain.Models;

public class State : BaseModel
{

	public string StateName = default!;

	public int CountryId { get; set; }

	#region Navigation Properties
	public virtual Country? Country { get; set; }
	#endregion
}
