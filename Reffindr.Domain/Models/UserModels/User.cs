using System.ComponentModel.DataAnnotations;

namespace Reffindr.Domain.Models.UserModels;
public class User : BaseModel
{
    public int RoleId { get; set; }
    public int? CountryId { get; set; }
    public int? StateId { get; set; }
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Dni { get; set; } = default!;
    public string? Phone { get; set; } = default!;
    public string? Address { get; set; } = default!;
    public DateTime? BirthDate { get; set; }
    [EmailAddress]
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public bool IsProfileComplete { get; set; }
    public int? GenreId { get; set; }
    public int? UserOwnerInfoId { get; set; }
    public int? UserTenantInfoId { get; set; }

    #region NavigationProperties
    public virtual Role? Role { get; set; }
    public virtual Country? Country { get; set; }
    public virtual State? State { get; set; }
    public virtual List<ApplicationModel>? Applications { get; set; }
    public virtual UserOwnerInfo? UserOwnerInfo { get; set; }
    public virtual UserTenantInfo? UserTenantInfo { get; set; }
    public virtual List<Notification>? Notifications { get; set; }
    public virtual List<Rating>? RatingsGiven { get; set; }
    public virtual List<Rating>? RatingsReceived { get; set; }
    public virtual Image? Image { get; set; }
    public virtual Genre? Genre { get; set; }
    public virtual List<Favorite>? FavoriteProperties { get; set; }
    #endregion NavigationProperties
}