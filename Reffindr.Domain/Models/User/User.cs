using System.ComponentModel.DataAnnotations;

namespace Reffindr.Domain.Models.User;

public class User : BaseModel
{
    public int RoleId { get; set; }
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    [EmailAddress]
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;

    #region NavigationProperties

    public virtual Role? Role { get; set; }
    public virtual UserOwnerInfo? UserOwnerInfo { get; set; }    
    public virtual UserTenantInfo? UserTenantInfo { get; set; }    

    #endregion NavigationProperties
}
