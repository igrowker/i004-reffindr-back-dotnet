using Reffindr.Shared.DTOs.Request.Application;
using Reffindr.Shared.DTOs.Response.Application;
using Reffindr.Shared.Result;

namespace Reffindr.Application.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<Result<List<ApplicationGetResponseDto>>> GetApplicationsByUserIdAsync(int userId);
        Task<Result<ApplicationPostResponseDto>> PostApplicationAsync(ApplicationPostRequestDto applicationPostRequestDto, CancellationToken cancellationToken);
    }
}
