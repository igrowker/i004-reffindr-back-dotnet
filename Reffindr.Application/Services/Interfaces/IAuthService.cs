using Reffindr.Shared.DTOs.Request.Auth;
using Reffindr.Shared.DTOs.Response.Auth;

namespace Reffindr.Application.Services.Interfaces;

public interface IAuthService
{
    Task<UserRegisterResponseDto> SignUpUserAsync(UserRegisterRequestDto userRegisterRequestDto, CancellationToken cancellationToken);
}
