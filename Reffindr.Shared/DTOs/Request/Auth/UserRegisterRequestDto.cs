namespace Reffindr.Shared.DTOs.Request.Auth;

public class UserRegisterRequestDto
{
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public int RoleId { get; set; } = default!;
}
