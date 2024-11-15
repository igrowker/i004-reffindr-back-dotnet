namespace Reffindr.Domain.Models;

public class Country : BaseModel
{

	public string CountryName { get; set; } = default!;

	#region Navigation Properties

	public virtual List<State>? State { get; set; }
	#endregion

}
