using Reffindr.Application.Services.Validations.Interfaces;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.UnitOfWork;

namespace Reffindr.Application.Services.Validations.Classes
{
    public class ApplicationValidationService : IApplicationValidationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;

        public ApplicationValidationService(IUnitOfWork unitOfWork, IUserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
        }

        // Validación para veritificar si la persona que quiere ver las aplicaciones es el dueño de las mismas o un inquilino saliente que publicó la propiedad
        public async Task<bool> UserIsOwnerOrTenant(int propertyId)
        {
            int userId = _userContext.GetUserId();
            Tuple<int?, int?> propertyUser = await _unitOfWork.PropertiesRepository.GetOwnerIdAndTenantId(propertyId);

            return propertyUser.Item1 == userId || propertyUser.Item2 == userId;
        }

        public async Task<bool> PropertyExists(int propertyId)
        {
            var property = await _unitOfWork.PropertiesRepository.GetById(propertyId);
            return property != null && !property.IsDeleted;
        }

        public async Task<bool> UserHasCompleteProfile()
        {
            int userId = _userContext.GetUserId();
            var user = await _unitOfWork.UsersRepository.GetById(userId);
            return user != null && user.IsProfileComplete;
        }

        public async Task<bool> UserHasNotApplied(int propertyId)
        {
            int userId = _userContext.GetUserId();
            return !await _unitOfWork.ApplicationRepository.ExistsAsync(userId, propertyId);
        }

        // Esta validación es para el caso de que el usuario cumpla con los requisitos de la propiedad
        public async Task<bool> UserMeetsRequirements(int propertyId)
        {
            int userId = _userContext.GetUserId();

            var property = await _unitOfWork.PropertiesRepository.GetByIdWithRequirementsAsync(propertyId);
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

                //if (property.Requirement.RangeSalary.HasValue &&
                //    tenantInfo.RangeSalary < property.Requirement.RangeSalary.Value)
                //{
                //    return false;
                //}
            }

            return true;
        }
    }
}
