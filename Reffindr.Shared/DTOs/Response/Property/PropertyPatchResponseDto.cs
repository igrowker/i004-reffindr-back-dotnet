using static System.Net.Mime.MediaTypeNames;

namespace Reffindr.Shared.DTOs.Response.Property;

public class PropertyPatchResponseDto
{
    public int? PropertyId { get; set; }
    public int? TenantId { get; set; }
    public int? OwnerId { get; set; }

}


