namespace Reffindr.Domain.Models.UserModels;

public class Salary : BaseModel
{
    public string SalaryName { get; set; } = default!;

    #region Navigation Properties
    public virtual List<User>? Users { get; set; }
    #endregion Navigation Properties
}
