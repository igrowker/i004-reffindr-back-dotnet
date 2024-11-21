using FluentValidation;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Request.Application;

namespace Reffindr.Application.Services.Validations.Classes
{
    public class ApplicationValidationService : AbstractValidator<ApplicationPostRequestDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;

        public ApplicationValidationService(IUnitOfWork unitOfWork, IUserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;

            RuleFor(a => a.PropertyId)
                .GreaterThan(0).WithMessage("El ID de la propiedad debe ser mayor que cero.")
                .MustAsync(PropertyExists).WithMessage("La propiedad especificada no existe.")
                .DependentRules(() =>
                {
                    RuleFor(a => a).MustAsync(UserHasNotApplied).WithMessage("Ya has aplicado a esta propiedad.")
                                   .MustAsync(UserMeetsRequirements).WithMessage("No cumples con los requisitos de esta propiedad.")
                                   .MustAsync(UserHasCompleteProfile).WithMessage("Debes completar tu perfil antes de aplicar a una propiedad.")
                                   .Must(UserIsTenant).WithMessage("Solo los inquilinos pueden aplicar a propiedades.");
                });
        }

        private async Task<bool> PropertyExists(int propertyId, CancellationToken cancellationToken)
        {
            var property = await _unitOfWork.PropertiesRepository.GetByIdWithRequirementsAsync(propertyId);
            return property != null && !property.IsDeleted;
        }

        private async Task<bool> UserHasNotApplied(ApplicationPostRequestDto dto, CancellationToken cancellationToken)
        {
            int userId = _userContext.GetUserId();
            return !await _unitOfWork.ApplicationRepository.ExistsAsync(userId, dto.PropertyId);
        }

        private async Task<bool> UserMeetsRequirements(ApplicationPostRequestDto dto, CancellationToken cancellationToken)
        {
            int userId = _userContext.GetUserId();

            var property = await _unitOfWork.PropertiesRepository.GetByIdWithRequirementsAsync(dto.PropertyId);
            var tenantInfo = await _unitOfWork.UserTenantInfoRepository.GetById(userId);

            if (tenantInfo == null)
            {
                return false;
            }

            if (property?.Requirement != null)
            {
                if (property.Requirement.IsWorking.HasValue &&
                    property.Requirement.IsWorking.Value &&
                    !tenantInfo.IsWorking)
                {
                    return false;
                }

                if (property.Requirement.HasWarranty.HasValue &&
                    property.Requirement.HasWarranty.Value &&
                    !tenantInfo.HasWarranty)
                {
                    return false;
                }

                if (property.Requirement.RangeSalary.HasValue &&
                    tenantInfo.RangeSalary < property.Requirement.RangeSalary.Value)
                {
                    return false;
                }
            }

            return true;
        }

        private async Task<bool> UserHasCompleteProfile(ApplicationPostRequestDto dto, CancellationToken cancellationToken)
        {
            int userId = _userContext.GetUserId();
            var user = await _unitOfWork.UsersRepository.GetById(userId);
            return user != null && user.IsProfileComplete;
        }

        private bool UserIsTenant(ApplicationPostRequestDto dto)
        {
            // Aqui definir si guardar el rol en el token o buscarlo en la base de datos
            return false;
        }
    }
}
