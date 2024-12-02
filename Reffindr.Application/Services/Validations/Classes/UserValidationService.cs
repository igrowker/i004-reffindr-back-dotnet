using Reffindr.Infrastructure.UnitOfWork;

namespace Reffindr.Application.Services.Validations.Classes;

public class UserValidationService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserValidationService
        (
            IUnitOfWork unitOfWork
        )
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        bool emailExists = await _unitOfWork.AuthRepository.EmailExists(email);

        return emailExists;
    }
}
