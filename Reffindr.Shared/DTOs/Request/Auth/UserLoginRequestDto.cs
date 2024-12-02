namespace Reffindr.Shared.DTOs.Request.Auth;

public class UserLoginRequestDto
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
