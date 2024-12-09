using Reffindr.Domain.Models;
using Reffindr.Shared.DTOs.Request.Application;
using Reffindr.Shared.DTOs.Response.Application;
using Reffindr.Shared.Result;

namespace Reffindr.Application.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<Result<List<ApplicationGetResponseDto>>> GetApplicationsByUserIdAsync();
        Task <List<ApplicationsWithUserGetResponseDto>> GetApplicationsByPropertyIdAsync(int propertyId);
        Task<Result<ApplicationPostResponseDto>> PostApplicationAsync(ApplicationPostRequestDto applicationPostRequestDto, CancellationToken cancellationToken);
        Task<List<ApplicationGetResponseDto>> GetApplicationsSelectedCandidatesAsync(int propertyId);
        Task<Candidate> PutSelectCandidatesAsync(int cantidateUserID, int propertyId, CancellationToken cancellationToken);
        Task<ApplicationModel> PutSelectNewTenantAsync(int userId, CancellationToken cancellationToken);
    }
}
