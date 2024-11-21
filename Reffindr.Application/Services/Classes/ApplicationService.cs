using Reffindr.Application.Services.Interfaces;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Response.Application;
using Reffindr.Shared.Result;
using Reffindr.Domain.Models;
using Reffindr.Shared.DTOs.Request.Application;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Storage;
using Reffindr.Application.Utilities.Mappers;

namespace Reffindr.Application.Services.Classes
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;

        public ApplicationService(IUnitOfWork unitOfWork, IUserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
        }

        public async Task<Result<List<ApplicationGetResponseDto>>> GetApplicationsByUserIdAsync(int userId)
        {
            int userCurrentId = _userContext.GetUserId();

            if (userId != userCurrentId)
            {
                return Result<List<ApplicationGetResponseDto>>.Failure("You don't have permissions to view another user's applications.");
            }

            List<ApplicationModel> applications = await _unitOfWork.ApplicationRepository.GetApplicationsByUserIdAsync(userId);

            if (applications == null || applications.Count == 0)
            {
                return Result<List<ApplicationGetResponseDto>>.Failure("No applications found for this user.");
            }

            // Mapeo manual
            List<ApplicationGetResponseDto> applicationDtos = applications.Select(a => new ApplicationGetResponseDto
            {
                Id = a.Id,
                PropertyId = a.PropertyId,
                PropertyTitle = a.Property?.Title ?? "No title",
                PropertyAddress = a.Property?.Address ?? "No address",
                Status = a.Status ?? "Unknown",
                CreatedAt = a.CreatedAt
            }).ToList();

            return Result<List<ApplicationGetResponseDto>>.Success(applicationDtos);
        }

        public async Task<ApplicationPostResponseDto> PostApplicationAsync(ApplicationPostRequestDto applicationPostRequestDto, CancellationToken cancellationToken)
        {
            using IDbContextTransaction transaction = await _unitOfWork.BeginTransaction(cancellationToken); 

            int userAuthenticated = _userContext.GetUserId();

            ApplicationModel applicationToCreate = applicationPostRequestDto.ToModel();
            applicationToCreate.UserId = userAuthenticated;
            applicationToCreate.Status = "Pending";

            ApplicationModel applicationCreated = await _unitOfWork.ApplicationRepository.Create(applicationToCreate, cancellationToken);
            ApplicationPostResponseDto applicationResponse = applicationCreated.ToResponse();

            Candidate candidateToCreate = new()
            {
                Application = applicationToCreate,
                SelectedByTenant = false
            };
            await _unitOfWork.CandidateRepository.Create(candidateToCreate, cancellationToken);

            await _unitOfWork.Complete(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return applicationResponse;
        }
    }
}
