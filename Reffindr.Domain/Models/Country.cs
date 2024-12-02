using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Domain.Models;

public class Country : BaseModel
{

	public string CountryName { get; set; } = default!;

	#region Navigation Properties

	public virtual List<State>? State { get; set; }
	public virtual List<Property>? Property { get; set; }
	public virtual List<User>? User { get; set; }

	#endregion

}
