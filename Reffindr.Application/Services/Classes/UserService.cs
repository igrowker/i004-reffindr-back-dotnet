using Reffindr.Application.Services.Interfaces;
using Reffindr.Infrastructure.UnitOfWork;

namespace Reffindr.Application.Services.Classes;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService
        (
            IUnitOfWork unitOfWork
        )
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<UserUpdateResponseDto> UpdateUserAsync(UserUpdateRequestDto userRequestDto, CancellationToken cancellationToken)
    {
        int userId = _userContext.GetUserId();

        User user = await _usersRepository.GetUserById(userId);

        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User cannot be null.");
        }

        user.Name = userRequestDto.Name ?? user.Name;
        user.LastName = userRequestDto.LastName ?? user.LastName;
        user.Dni = userRequestDto.Dni ?? user.Dni;
        user.Phone = userRequestDto.Phone ?? user.Phone;
        user.Address = userRequestDto.Address ?? user.Address;
        user.BirthDate = userRequestDto.BirthDate ?? user.BirthDate;
        user.UpdatedAt = DateTime.UtcNow;

        user.IsProfileComplete = !string.IsNullOrWhiteSpace(user.Name) &&
                             !string.IsNullOrWhiteSpace(user.LastName) &&
                             !string.IsNullOrWhiteSpace(user.Dni) &&
                             !string.IsNullOrWhiteSpace(user.Phone) &&
                             !string.IsNullOrWhiteSpace(user.Address) &&
                             user.BirthDate.HasValue;

        await _unitOfWork.Complete(cancellationToken);

        UserUpdateResponseDto userUpdateResponseDto = user.ToResponse();

        return userUpdateResponseDto;

    }



}
