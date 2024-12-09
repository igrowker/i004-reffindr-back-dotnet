namespace Reffindr.Domain.Models.UserModels;

public class UserOwnerInfo : BaseModel
{
    public bool IsCompany { get; set; } = default!;
    public int UserId { get; set; }
    public virtual User? User { get; set; }

}
