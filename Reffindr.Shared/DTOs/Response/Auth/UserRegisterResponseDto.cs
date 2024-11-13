namespace Reffindr.Shared.DTOs.Response.Auth;

public class UserRegisterResponseDto
{
    public string Email { get; set; } = default!;

    public string Token { get; set; } = default!;
}
