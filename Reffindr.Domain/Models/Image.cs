using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Domain.Models;

public class Image : BaseModel
{
    public int? PropertyId { get; set; }
    public int? UserId { get; set; }
    public  List<string>? ImageUrl { get; set; }

#region Navigation Properties
    public virtual Property? Property { get; set; } = default!;
    public virtual User? User { get; set; } = default!;

	#endregion
}
