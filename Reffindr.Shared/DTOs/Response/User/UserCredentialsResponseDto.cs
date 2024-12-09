namespace Reffindr.Shared.DTOs.Response.User;

public class UserCredentialsResponseDto
{
    public int RoleId { get; set; }
    public string? RoleName { get; set; } = default!;
    public int? CountryId { get; set; }
    public int? StateId { get; set; }
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Dni { get; set; } = default!;
    public string? Phone { get; set; } = default!;
    public string? Address { get; set; } = default!;
    public DateTime? BirthDate { get; set; }
    public string Email { get; set; } = default!;
    public bool IsProfileComplete { get; set; }
    public int? GenderId { get; set; }
    public string? GenderName { get; set; }
    public int? SalaryId { get; set; }
    public string? SalaryName { get; set; }
    public string? ImageProfileUrl { get; set; }
}
