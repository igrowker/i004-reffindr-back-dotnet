namespace Reffindr.Domain.Models.UserModels;

public class Genre : BaseModel
{
    public string GenreName { get; set; } = default!;

    #region Navigation Properties
    public virtual List<User>? Users { get; set; }
    #endregion Navigation Properties
}
