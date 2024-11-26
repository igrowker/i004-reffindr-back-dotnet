using Reffindr.Shared.DTOs.Request.Application;

namespace Reffindr.Application.Services.Validations.Interfaces
{
    public interface IApplicationValidationService
    {
        Task<bool> PropertyExists(int propertyId);
        Task<bool> UserHasNotApplied(int propertyId);
        Task<bool> UserMeetsRequirements(int propertyId);
        Task<bool> UserHasCompleteProfile();
        Task<bool> UserIsOwnerOrTenant(int propertyId);
    }
}
