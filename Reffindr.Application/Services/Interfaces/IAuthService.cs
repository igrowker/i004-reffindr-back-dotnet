using Reffindr.Shared.DTOs.Request.Auth;
using Reffindr.Shared.DTOs.Response.Auth;
using System.Security.Claims;

namespace Reffindr.Application.Services.Interfaces;

public interface IAuthService
{
    int GetUserId(ClaimsPrincipal user);
    Task<UserLoginResponseDto> LoginUserAsync(UserLoginRequestDto userLoginRequestDto, CancellationToken cancellationToken);
    Task<UserRegisterResponseDto> SignUpUserAsync(UserRegisterRequestDto userRegisterRequestDto, CancellationToken cancellationToken);
}
