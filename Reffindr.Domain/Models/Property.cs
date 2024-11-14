namespace Reffindr.Domain.Models;

public class Property : BaseModel
{
    public int RequirementId { get; set; }
    public int OwnerId { get; set; }
    public string Title { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Description { get; set; } = default!;

    #region Navigation Property
    public virtual Requirement? Requirement { get; set; }

    #endregion Navigation Property
}
