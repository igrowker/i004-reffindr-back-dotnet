using Reffindr.Shared.DTOs.Request.Auth;
using Reffindr.Shared.DTOs.Response.Auth;

namespace Reffindr.Application.Services.Interfaces;

public interface IAuthService
{
    Task<UserLoginResponseDto> LoginUserAsync(UserLoginRequestDto userLoginRequestDto, CancellationToken cancellationToken);
    Task<UserRegisterResponseDto> SignUpUserAsync(UserRegisterRequestDto userRegisterRequestDto, CancellationToken cancellationToken);
}
