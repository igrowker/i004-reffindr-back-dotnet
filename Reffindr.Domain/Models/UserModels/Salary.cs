namespace Reffindr.Domain.Models.UserModels;

public class Salary : BaseModel
{
    public string SalaryName { get; set; } = default!;

    #region Navigation Properties
    public virtual List<UserTenantInfo>? UsersTenantInfo { get; set; }
    #endregion Navigation Properties
}
