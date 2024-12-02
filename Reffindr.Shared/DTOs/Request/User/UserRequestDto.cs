namespace Reffindr.Shared.DTOs.Request.User;

public class UserRequestDto
{
    public string? name { get; set; } = default!;
    public string email { get; set; } = default!;
    public string? role { get; set; } = default!;
    public string password { get; set; } = default!;
}
