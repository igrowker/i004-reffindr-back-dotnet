namespace Reffindr.Domain.Models.UserModels;

public class Role : BaseModel
{
    public string RoleName { get; set; } = default!;

    #region Navigation Properties
    public virtual List<User>? Users { get; set; }
    #endregion Navigation Properties
}
