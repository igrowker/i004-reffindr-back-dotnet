namespace Reffindr.Shared.DTOs.Response.User;

public class UserUpdateRequestDto
{
    public string? email { get; set; } = default!;
    public string? Name { get; set; } = default!;
    public string? LastName { get; set; } = default!;
    public string? Dni { get; set; } = default;
    public string? Phone { get; set; } = default!;
    public string? Address { get; set; }
    public DateTime? BirthDate { get; set; }
}
