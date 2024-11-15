namespace Reffindr.Domain.Models;

public class Property : BaseModel
{
	public int RequirementId { get; set; }
	public int OwnerId { get; set; }
	public string Title { get; set; } = default!;
	public string Address { get; set; } = default!;
	public string Description { get; set; } = default!;
	public int CountryId { get; set; }
	public int StateId { get; set; }

	#region Navigation Properties

	public virtual Requirement? Requirement { get; set; }
	public virtual Country? Country { get; set; }
	public virtual State? State { get; set; }

	#endregion Navigation Properties
}
