namespace Reffindr.Domain.Models;

public class Requirement : BaseModel
{
    public bool? IsWorking { get; set; }
    public bool? HasWarranty { get; set; }
    public decimal? RangeSalary { get; set; } = default!;

    #region Navigation Properties
    public Property? Property { get; set; }
    #endregion
}
