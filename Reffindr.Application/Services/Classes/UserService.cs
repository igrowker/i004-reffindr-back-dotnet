using Reffindr.Application.Services.Interfaces;
using Reffindr.Application.Utilities.Mappers;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.Repositories.Interfaces;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Pagination;
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

    public async Task<UserUpdateResponseDto> UpdateUserAsync(UserUpdateRequestDto userUpdateRequestDto,
        CancellationToken cancellationToken)
    {
        int userId = _userContext.GetUserId();

        Image userImageDb = await _unitOfWork.ImageRepository.GetImage(userId);

        User userToUpdate = null;
        User userDataInDb = await _unitOfWork.UsersRepository.GetById(userId);

        if (userUpdateRequestDto.ProfileImage is not null)
        {
            List<string> userImageProfile = new List<string>();
            string imageUrl = await _imageService.UploadImagesAsync(userUpdateRequestDto.ProfileImage!);
            userImageProfile.Add(imageUrl);
            userImageDb.ImageUrl = userImageProfile;
            await _unitOfWork.ImageRepository.Update(userImageDb.Id, userImageDb);
        }

        if (userDataInDb.RoleId == 1)
        {
            UserTenantInfo userDataInDbTenantInfo = await _unitOfWork.UserTenantInfoRepository.GetTenantByUserId(userId);
            userDataInDb.UserTenantInfo = userDataInDbTenantInfo;
            userToUpdate = userUpdateRequestDto.ToModel(userDataInDb);

        }

        if (userDataInDb.RoleId == 2)
        {
            UserOwnerInfo userOwnerInfo = await _unitOfWork.UserOwnerInfoRepository.GetOwnerInfoByUserId(userId);
            userDataInDb.UserOwnerInfo = userOwnerInfo;
            userToUpdate = userUpdateRequestDto.ToModel(userDataInDb);

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
        Image userImageDb = await _unitOfWork.ImageRepository.GetImage(userId);
        Role roleDb = await _unitOfWork.RoleRepository.GetById(userCredentials.RoleId);
        if(userCredentials.GenreId is not null)
        {
            Genre genreDb = await _unitOfWork.GenreRepository.GetById(userCredentials.GenreId);
            userCredentials.Genre = genreDb;
        }
        userCredentials.Image = userImageDb;
        userCredentials.Role = roleDb;

        UserCredentialsResponseDto userCredentialsResponse = new UserCredentialsResponseDto();
        if (userCredentials.RoleId == 1)
        {
            UserTenantInfo userTenantInfo = await _unitOfWork.UserTenantInfoRepository.GetTenantByUserId(userId);
            Salary salaryDb = await _unitOfWork.SalaryRepository.GetById(userTenantInfo.SalaryId);
            userTenantInfo.Salary = salaryDb;
            userCredentials.UserTenantInfo = userTenantInfo;
            userCredentialsResponse = userCredentials.ToUserCredentialsResponse();

        }
        if (userCredentials.RoleId == 2)
        {
            UserOwnerInfo userOwnerInfo = await _unitOfWork.UserOwnerInfoRepository.GetOwnerInfoByUserId(userId);
            userCredentials.UserOwnerInfo = userOwnerInfo;
            userCredentialsResponse = userCredentials.ToUserCredentialsOwnerResponse();
        }

        return userCredentialsResponse;
    }
}