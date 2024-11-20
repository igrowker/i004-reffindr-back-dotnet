using Reffindr.Shared.DTOs.Request.Requirement;

namespace Reffindr.Shared.DTOs.Request.Property;

public class PropertyPostRequestDto
{
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public string Title { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Email { get; set; }= default!;

    public virtual RequirementPostRequestDto? RequirementPostRequestDto { get; set; }
}
