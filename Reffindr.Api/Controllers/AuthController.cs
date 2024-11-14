using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Shared.DTOs.Request.Auth;
using Reffindr.Shared.DTOs.Response.Auth;

namespace Reffindr.Api.Controllers;

[Route("api/[controller]")]
[AllowAnonymous]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController
        (
            IAuthService authService 
        )
    {
        _authService=authService;
    }

    /// <summary>
    /// Register a new user in the system.
    /// </summary>
    /// <remarks>
    /// This endpoint allows the creation of a new user. The user's password is encrypted using SHA-256 before storing it in the database.
    /// </remarks>
    /// <param name="userRegisterRequestDto">The user registration details including email, role, name, and password.</param>
    /// <param name="cancellationToken">The user registration details including email, role, name, and password.</param>
    /// <returns>Returns a status indicating whether the registration was successful or not.</returns>
    /// <response code="200">If the user was created successfully, returns isSucces=true; otherwise, returns isSucces=false.</response>
    [HttpPost]
    [Route("SignUp")]
    public async Task<IActionResult> SignUp([FromBody] UserRegisterRequestDto userRegisterRequestDto, CancellationToken cancellationToken)
    {
        UserRegisterResponseDto userRegisterResponse = await _authService.SignUpUserAsync(userRegisterRequestDto, cancellationToken);

        if (userRegisterResponse is null) return BadRequest("El email ya se encuentra registrado en nuestra base de datos.");

        return Ok(userRegisterResponse);
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto userLoginRequestDto, CancellationToken cancellationToken)
    {
        UserLoginResponseDto userLoginResponseDto = await _authService.LoginUserAsync(userLoginRequestDto, cancellationToken);

        return Ok(userLoginResponseDto);
    }

}
