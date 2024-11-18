namespace Reffindr.Shared.DTOs.Request.Property;

public class PropertyPostRequestDto
{
    public int OwnerId { get; set; }
    public int TenantId { get; set; }
    public int RequirementId { get; set; }
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public string Title { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Description { get; set; } = default!;
}
