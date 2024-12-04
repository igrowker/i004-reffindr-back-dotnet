namespace Reffindr.Shared.DTOs.Response.User;

public class UserUpdateResponseDto
{
    public string Email { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Dni { get; set; } = default;
    public string? Phone { get; set; } = default!;
    public string? Address { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool? IsProfileComplete { get; set; }
    public string? ImageProfileUrl { get; set; }
    public int? GenreId { get; set; }
    public int? SalaryId { get; set; }
    public int? CountryId { get; set; }
    public int? StateId { get; set; }
    
    
}
