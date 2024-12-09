using Reffindr.Shared.DTOs.Response.User;

namespace Reffindr.Shared.DTOs.Response.Application;

public class ApplicationsWithUserGetResponseDto
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public string PropertyTitle { get; set; } = default!;
    public string PropertyAddress { get; set; } = default!;
    public string Status { get; set; } = default!;
    public DateTime CreatedAt { get; set; }

    public UserResponseDto? UserResponseDto { get; set; }
}
