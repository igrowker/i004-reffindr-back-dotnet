namespace Reffindr.Domain.Models.UserModels;

public class UserTenantInfo : BaseModel
{
    public bool IsWorking { get; set; }
    public bool HasWarranty { get; set; }
    public int UserId { get; set; }
    public int? SalaryId { get; set; }

    public virtual User? User { get; set; }
    public virtual Salary? Salary { get; set; }


}
