namespace Reffindr.Domain.Models;

public class User : BaseModel
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Role { get; set; } = default!;

    #region NavigationProperties

    #endregion NavigationProperties
}
