namespace Reffindr.Shared.DTOs.Response.Property;

public class PropertyPostResponseDto
{
    public int RequirementId { get; set; }
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public string Title { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Description { get; set; } = default!;
}

