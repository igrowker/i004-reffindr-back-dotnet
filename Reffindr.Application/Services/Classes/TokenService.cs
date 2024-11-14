using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Reffindr.Application.Services.Classes;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string GenerateJWT(User user)
    {
        string? secretKey = _configuration["Jwt:key"];
        var userClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(ClaimTypes.Name, user.Name!),
        };
        var keyBytes = Encoding.UTF8.GetBytes(secretKey!);
        var securityKey = new SymmetricSecurityKey(keyBytes);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
             claims: userClaims,
             expires: DateTime.UtcNow.AddMinutes(10),
             signingCredentials: credentials
         );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
