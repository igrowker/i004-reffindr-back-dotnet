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
using Reffindr.Application.Services.Validations.Interfaces;

namespace Reffindr.Application.Services.Classes
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;
        private readonly IApplicationValidationService _applicationValidationService;

        public ApplicationService(IUnitOfWork unitOfWork, IUserContext userContext, IApplicationValidationService applicationValidationService)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
            _applicationValidationService = applicationValidationService;
        }

        public async Task<Result<List<ApplicationGetResponseDto>>> GetApplicationsByUserIdAsync(int userId)
        {
            int userAutenticado = _userContext.GetUserId();

            if (userId != userAutenticado)
            {
                return Result<List<ApplicationGetResponseDto>>.Failure("No tienes permisos para ver las aplicaciones de otro usuario.");
            }

            List<ApplicationModel> applications = await _unitOfWork.ApplicationRepository.GetApplicationsByUserIdAsync(userId);

            if (applications == null || !applications.Any())
            {
                return Result<List<ApplicationGetResponseDto>>.Failure("No se encontraron aplicaciones para este usuario.");
            }

            // Mapeo manual
            List<ApplicationGetResponseDto> applicationDtos = applications.Select(a => new ApplicationGetResponseDto
            {
                Id = a.Id,
                PropertyId = a.PropertyId,
                PropertyTitle = a.Property?.Title ?? "Sin título",
                PropertyAddress = a.Property?.Address ?? "Sin dirección",
                Status = a.Status ?? "Desconocido",
                CreatedAt = a.CreatedAt
            }).ToList();

            return Result<List<ApplicationGetResponseDto>>.Success(applicationDtos);
        }

        public async Task<Result<ApplicationPostResponseDto>> PostApplicationAsync(ApplicationPostRequestDto applicationPostRequestDto, CancellationToken cancellationToken)
        {
            using IDbContextTransaction transaction = await _unitOfWork.BeginTransaction(cancellationToken); 

            int userAuthenticated = _userContext.GetUserId();
            int userRoleId = _userContext.GetRoleId();

            // Verificar si el usuario es inquilino
            if (userRoleId != 1)
            { 
                return Result<ApplicationPostResponseDto>.Failure("Solo los inquilinos pueden aplicar a propiedades.");
            }

            // Verificar si la propiedad existe
            var propertyExists = await _applicationValidationService.PropertyExists(applicationPostRequestDto.PropertyId);
            if (!propertyExists)
            {
                return Result<ApplicationPostResponseDto>.Failure("La propiedad no existe");
            }

            // Verificar si el usuario ya ha aplicado a esta propiedad
            bool userHasApplied = await _applicationValidationService.UserHasNotApplied(applicationPostRequestDto.PropertyId);
            if (!userHasApplied)
            {
                return Result<ApplicationPostResponseDto>.Failure("Ya has aplicado a esta propiedad.");
            }

            // Verificar si el usuario tiene un perfil completo
            bool userHasCompleteProfile = await _applicationValidationService.UserHasCompleteProfile();
            if (!userHasCompleteProfile)
            {
                return Result<ApplicationPostResponseDto>.Failure("Debes completar tu perfil antes de aplicar a una propiedad.");
            }

            // Verificar si el usuario cumple con los requisitos de la propiedad
            var tenantInfo = await _applicationValidationService.UserMeetsRequirements(applicationPostRequestDto.PropertyId);
            if (!tenantInfo)
            {
                return Result<ApplicationPostResponseDto>.Failure("El usuario no cumple con los requisitos solicitados para la propiedad.");
            }

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

            return Result<ApplicationPostResponseDto>.Success(applicationResponse);
        }
    }
}
