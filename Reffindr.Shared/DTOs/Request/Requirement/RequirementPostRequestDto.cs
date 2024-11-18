namespace Reffindr.Shared.DTOs.Request.Requirement;

public class RequirementPostRequestDto
{
    public bool IsWorking { get; set; }
    public bool HasWarranty { get; set; }
    public decimal RangeSalary { get; set; } = default!;
}
