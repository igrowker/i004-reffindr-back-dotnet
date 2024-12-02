﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Domain.Models.UserModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Reffindr.Application.Services.Classes;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly SymmetricSecurityKey _key;
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
        _key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_configuration["JWT:Key"]!));
    }

    public string GenerateJWT(User user)
    {
        string? secretKey = _configuration["Jwt:key"];
        
        List<Claim> claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Name, user.Name),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.RoleId.ToString())
        };
        SigningCredentials credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(5),
            SigningCredentials = credentials,
            Issuer = _configuration["JWT:Issuer"],
            Audience = _configuration["JWT:Audience"]
        };

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public string CleanToken(string token)
    {
        string cleanToken = token.StartsWith("Bearer ") ? token.Substring("Bearer ".Length) : token;

        if (string.IsNullOrWhiteSpace(cleanToken))
        {
            throw new Exception("Token nulo o vacío.");
        }

        string decodedToken = DecodeToken(cleanToken!);

        return decodedToken;
    }

    public string DecodeToken(string token)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            JwtSecurityToken decodedToken = tokenHandler.ReadJwtToken(token);

            var userIdClaim = decodedToken.Claims.FirstOrDefault(claim => claim.Type == "sub");

            if (userIdClaim == null)
            {
                throw new Exception("El claim 'sub' no se encuentra en el token.");
            }

            return userIdClaim.Value;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al decodificar el token: {ex.Message}");
        }
    }
   
}
