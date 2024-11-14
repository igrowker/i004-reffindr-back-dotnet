using Microsoft.AspNetCore.Identity;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Application.Utilities.Mappers;
using Reffindr.Domain.Models;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Request.Auth;
using Reffindr.Shared.DTOs.Response.Auth;

namespace Reffindr.Application.Services.Classes;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;
    public AuthService
        (
            ITokenService tokenService, 
            IUnitOfWork unitOfWork
        )
	{
        _tokenService = tokenService;
        _unitOfWork = unitOfWork;
        _passwordHasher = new PasswordHasher<User>();
    }

	public async Task<UserRegisterResponseDto> SignUpUserAsync(UserRegisterRequestDto userRegisterRequestDto, CancellationToken cancellationToken) 
	{
        User userToRegister = userRegisterRequestDto.ToModel();

        userToRegister.Password = _passwordHasher.HashPassword(userToRegister, userToRegister.Password);

        User registeredUser = await _unitOfWork.AuthRepository.Create(userToRegister, cancellationToken);

        await _unitOfWork.Complete(cancellationToken);

        string token = _tokenService.GenerateJWT(registeredUser);

        UserRegisterResponseDto registeredUserResponse = registeredUser.ToRegisterResponseDto(token);

        return registeredUserResponse;
    }

    public async Task<UserLoginResponseDto> LoginUserAsync(UserLoginRequestDto userLoginRequestDto, CancellationToken cancellationToken)
    {
        User userLoginRequestData = userLoginRequestDto.ToModel();
        User userDataFromDb = await _unitOfWork.AuthRepository.GetByEmail(userLoginRequestData);

        PasswordVerificationResult passwordVerification = _passwordHasher.VerifyHashedPassword(userDataFromDb, userDataFromDb.Password, userLoginRequestData.Password);

        if (passwordVerification == PasswordVerificationResult.Failed) throw new Exception("Las credenciales no son correctas");

        string token = _tokenService.GenerateJWT(userDataFromDb);
        UserLoginResponseDto loggedUserResponse = userDataFromDb.ToLoginResponseDto(token);

        return loggedUserResponse;
    }
}
