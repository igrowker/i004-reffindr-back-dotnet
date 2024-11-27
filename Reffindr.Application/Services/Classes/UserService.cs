using Reffindr.Application.Services.Interfaces;
using Reffindr.Application.Utilities.Mappers;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.Repositories.Interfaces;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Request.User;
using Reffindr.Shared.DTOs.Response.User;
using System.Data;
using System.Threading;

namespace Reffindr.Application.Services.Classes;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;
    private readonly IUsersRepository _usersRepository;

    public UserService
        (
            IUnitOfWork unitOfWork,
            IUserContext userContext,
            IUsersRepository usersRepository
        )
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
        _usersRepository = usersRepository;
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
