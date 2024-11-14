namespace Reffindr.Domain.Models.User;

public class UserTenantInfo : BaseModel
{
    public bool IsWorking { get; set; }
    public bool HasWarranty { get; set; }
    public decimal RangeSalary { get; set; } = default!;
    public int UserId { get; set; }

    public User? User { get; set; }
}
