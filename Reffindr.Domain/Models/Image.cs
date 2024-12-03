using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Domain.Models;

public class Image : BaseModel
{
    public int? PropertyId { get; set; }
    public int? UserId { get; set; }
    public string ImageUrl { get; set; } = default!;

    #region Navigation Properties
    public Property? Property { get; set; } = default!;
    public User? User { get; set; } = default!;

	#endregion
}
