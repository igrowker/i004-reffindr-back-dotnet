using Microsoft.AspNetCore.Http;

namespace Reffindr.Domain.Models;

public class Property : BaseModel
{
    public int OwnerId { get; set; }
    public int TenantId { get; set; }
    public int? RequirementId { get; set; }
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public string Title { get; set; } = default!;
    public string Address { get; set; } = default!;
    public decimal Price { get; set; }
    public int Environments { get; set; }
    public int Bathrooms { get; set; }
    public int Bedrooms { get; set; }
    public int Seniority { get; set; }
    public bool Water { get; set; }
    public bool Gas { get; set; }
    public bool Surveillance { get; set; }
    public bool Electricity { get; set; }
    public bool Internet { get; set; }
    public bool Pool { get; set; }
    public bool Garage { get; set; }
    public bool Pets { get; set; }
    public bool Grill { get; set; }
    public bool Elevator { get; set; }
    public bool Terrace { get; set; }
	  public bool IsHistoric { get; set; }
	  public string Description { get; set; } = default!;

    #region Navigation Properties

   public virtual Requirement? Requirement { get; set; }
	 public virtual Country? Country { get; set; }
	 public virtual State? State { get; set; }

	public virtual List<Notification>? Notification { get; set; }
	 public virtual List<ApplicationModel>? Application { get; set; }
   public virtual List<Favorite>? FavoriteByUsers { get; set; }
   public virtual Image? Images { get; set; }


    #endregion Navigation Properties
}
