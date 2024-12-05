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
using Reffindr.Domain.Models.UserModels;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.Enum;

namespace Reffindr.Application.Services.Classes
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;
        private readonly IApplicationValidationService _applicationValidationService;
        private readonly INotificationService _notificationService;

        public ApplicationService(IUnitOfWork unitOfWork, IUserContext userContext, IApplicationValidationService applicationValidationService, INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
            _applicationValidationService = applicationValidationService;
            _notificationService = notificationService;
        }

        public async Task<Result<List<ApplicationGetResponseDto>>> GetApplicationsByUserIdAsync()
        {
            int userCurrentId = _userContext.GetUserId();

            List<ApplicationModel> applications = await _unitOfWork.ApplicationRepository.GetApplicationsByUserIdAsync(userCurrentId);

            // Mapeo
            List<ApplicationGetResponseDto> applicationDtos = applications.Select(a => a.ToGetResponse()).ToList();

            return Result<List<ApplicationGetResponseDto>>.Success(applicationDtos);
        }

        public async Task<List<ApplicationGetResponseDto>> GetApplicationsByPropertyIdAsync(int propertyId)
        {
            // No sé si agregar una validación para que solo pueda obtener las aplicaciones el dueño de la propiedad o el inquilino saliente que la publicó
            bool userIsOwnerOrTenant = await _applicationValidationService.UserIsOwnerOrTenant(propertyId);

            //if (!userIsOwnerOrTenant)
            //{
            //    throw new Exception("You don't have permissions to view applications for this property.");
            //}

            List<ApplicationModel> applications = await _unitOfWork.ApplicationRepository.GetApplicationsByPropertyIdAsync(propertyId);

            // Mapeo
            List<ApplicationGetResponseDto> applicationDtos = applications.Select(a => a.ToGetResponse()).ToList();

            return applicationDtos;
        }

        public async Task<List<ApplicationGetResponseDto>> GetApplicationsSelectedCandidatesAsync(int propertyId)
        {
            // No sé si agregar una validación para que solo pueda obtener las aplicaciones el dueño de la propiedad o el inquilino saliente que la publicó
            //bool userIsOwnerOrTenant = await _applicationValidationService.UserIsOwnerOrTenant(propertyId);

            //if (!userIsOwnerOrTenant)
            //{
            //    throw new Exception("You don't have permissions to view applications for this property.");
            //}

            List<ApplicationModel> applications = await _unitOfWork.ApplicationRepository.GetApplicationsSelectedCandidates(propertyId);

            // Mapeo
            List<ApplicationGetResponseDto> applicationDtos = applications.Select(a => a.ToGetResponse()).ToList();

            return applicationDtos;
        }

        public async Task<Result<ApplicationPostResponseDto>> PostApplicationAsync(ApplicationPostRequestDto applicationPostRequestDto, CancellationToken cancellationToken)
        {
            using IDbContextTransaction transaction = await _unitOfWork.BeginTransaction(cancellationToken);

            int userAuthenticated = _userContext.GetUserId();
            int userRoleId = _userContext.GetRoleId();

            // Verificar si el usuario es inquilino
            //if (userRoleId != 1)
            //{
            //    return Result<ApplicationPostResponseDto>.Failure("Solo los inquilinos pueden aplicar a propiedades.");
            //}

            // Verificar si la propiedad existe
            //var propertyExists = await _applicationValidationService.PropertyExists(applicationPostRequestDto.PropertyId);
            //if (!propertyExists)
            //{
            //    return Result<ApplicationPostResponseDto>.Failure("La propiedad no existe");
            //}

            // Verificar si el usuario ya ha aplicado a esta propiedad
            //bool userHasApplied = await _applicationValidationService.UserHasNotApplied(applicationPostRequestDto.PropertyId);
            //if (!userHasApplied)
            //{
            //    return Result<ApplicationPostResponseDto>.Failure("Ya has aplicado a esta propiedad.");
            //}

            // Verificar si el usuario tiene un perfil completo
            //bool userHasCompleteProfile = await _applicationValidationService.UserHasCompleteProfile();
            //if (!userHasCompleteProfile)
            //{
            //    return Result<ApplicationPostResponseDto>.Failure("Debes completar tu perfil antes de aplicar a una propiedad.");
            //}

            //// Verificar si el usuario cumple con los requisitos de la propiedad
            //var tenantInfo = await _applicationValidationService.UserMeetsRequirements(applicationPostRequestDto.PropertyId);
            //if (!tenantInfo)
            //{
            //    return Result<ApplicationPostResponseDto>.Failure("El usuario no cumple con los requisitos solicitados para la propiedad.");
            //}

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

            Property propertyInDb = await _unitOfWork.PropertiesRepository.GetById(applicationPostRequestDto.PropertyId);
            User userInDb = await _unitOfWork.UsersRepository.GetById(propertyInDb.TenantId);

            await _notificationService.AddNotificationToUser(userInDb.Email, applicationPostRequestDto.PropertyId, NotificationType.Application, cancellationToken);

            return Result<ApplicationPostResponseDto>.Success(applicationResponse);
        }

        public async Task<Candidate> PutSelectCandidatesAsync(int cantidateUserID, int propertyId, CancellationToken cancellationToken)
        {
            ApplicationModel userCandidateData = await _unitOfWork.ApplicationRepository.GetApplicationCandidate(cantidateUserID, propertyId);
            userCandidateData.Candidate!.SelectedByTenant = true;

           Candidate userCandidateDataUpdated = await _unitOfWork.CandidateRepository.Update(userCandidateData.Id, userCandidateData.Candidate);
           await _unitOfWork.Complete(cancellationToken);

            return userCandidateDataUpdated;
        }

    }
}
