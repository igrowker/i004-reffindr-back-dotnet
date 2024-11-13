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

        string token = _tokenService.generateJWT(registeredUser);

        UserRegisterResponseDto registeredUserResponse = registeredUser.ToResponseDto(token);

        return registeredUserResponse;
    }

    //public async Task<UserRegisterResponseDto> SignUpUserAsync(UserRegisterRequestDto userRegisterRequestDto, CancellationToken cancellationToken)
    //{
    //    PasswordVerificationResult passwordVerification = _passwordHasher.VerifyHashedPassword(userInDb, userInDb.Password, userData.Password);

    //    if (passwordVerification == PasswordVerificationResult.Failed) throw new Exception("Las credenciales no son correctas");
    //}
}
