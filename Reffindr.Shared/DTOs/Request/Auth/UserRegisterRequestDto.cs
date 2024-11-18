using System.ComponentModel.DataAnnotations;

namespace Reffindr.Shared.DTOs.Request.Auth;

public class UserRegisterRequestDto
{
    public int RoleId { get; set; }
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
