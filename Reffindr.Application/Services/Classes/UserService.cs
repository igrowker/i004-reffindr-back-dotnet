using Reffindr.Application.Services.Interfaces;
using Reffindr.Application.Utilities.Mappers;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.Repositories.Interfaces;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Response.User;

namespace Reffindr.Application.Services.Classes;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;
    private readonly IImageService _imageService;

    public UserService
        (
            IUnitOfWork unitOfWork,
            IUserContext userContext,
            IUsersRepository usersRepository,
            IImageService imageService
        )
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
        _imageService = imageService;
    }

    public async Task<UserUpdateResponseDto> UpdateUserAsync(UserUpdateRequestDto userUpdateRequestDto, CancellationToken cancellationToken)
    {
        int userId = _userContext.GetUserId();

        Image userImageDb = await _unitOfWork.ImageRepository.GetImage(userId);

        var userDataInDb = await _unitOfWork.UsersRepository.GetById(userId);
        User userToUpdate = userUpdateRequestDto.ToModel(userDataInDb);

       


        if (userUpdateRequestDto.ProfileImage is not null)
        {
            string imageUrl = await _imageService.UploadImagesAsync(userUpdateRequestDto.ProfileImage!);
            userImageDb.ImageUrl = imageUrl;
            await _unitOfWork.ImageRepository.Update(userImageDb.Id, userImageDb);
        }
       
        User userUpdated = await _unitOfWork.UsersRepository.Update(userId, userToUpdate);

        userUpdated.IsProfileComplete = !string.IsNullOrWhiteSpace(userUpdated.Name) &&
                             !string.IsNullOrWhiteSpace(userUpdated.LastName) &&
                             !string.IsNullOrWhiteSpace(userUpdated.Dni) &&
                             !string.IsNullOrWhiteSpace(userUpdated.Phone) &&
                             !string.IsNullOrWhiteSpace(userUpdated.Address) &&
                             userUpdated.BirthDate.HasValue;

        await _unitOfWork.Complete(cancellationToken);

        UserUpdateResponseDto userUpdateResponseDto = userUpdated.ToResponse();

        return userUpdateResponseDto;

    }

    public async Task<UserCredentialsResponseDto> GetUserCredentialsAsync()
    {
        int userId = _userContext.GetUserId();
        User userCredentials = await _unitOfWork.UsersRepository.GetById(userId);

        UserCredentialsResponseDto userCredentialsResponse = userCredentials.ToUserCredentialsResponse();

        return userCredentialsResponse;
    }


}
