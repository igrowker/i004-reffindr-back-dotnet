namespace Reffindr.Shared.DTOs.Response.User;

public class UserResponseDto
{
    public int? CountryId { get; set; }
    public int? StateId { get; set; }
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Dni { get; set; } = default!;
    public string? Phone { get; set; } = default!;
    public string? Address { get; set; } = default!;
    public DateTime? BirthDate { get; set; }
    public bool IsProfileComplete { get; set; }
    public int? GenreId { get; set; }
}
