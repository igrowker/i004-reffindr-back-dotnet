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
    /// Registra un nuevo usuario en el sistema.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite la creación de un nuevo usuario. La contraseña del usuario se encripta utilizando SHA-256 antes de almacenarla en la base de datos.
    /// </remarks>
    /// <param name="userRegisterRequestDto">Los detalles de registro del usuario, incluyendo email, rol, nombre y contraseña.</param>
    /// <param name="cancellationToken">Token de cancelación para controlar la operación asincrónica.</param>
    /// <returns>Devuelve un estado indicando si el registro fue exitoso o no.</returns>
    /// <response code="200">Si el usuario fue creado exitosamente devuelve el email y el token de acceso</response>
    [HttpPost]
    [Route("SignUp")]
    public async Task<IActionResult> SignUp([FromBody] UserRegisterRequestDto userRegisterRequestDto, CancellationToken cancellationToken)
    {
        UserRegisterResponseDto userRegisterResponse = await _authService.SignUpUserAsync(userRegisterRequestDto, cancellationToken);

        if (userRegisterResponse is null) return BadRequest("El email ya se encuentra registrado en nuestra base de datos.");

        return Ok(userRegisterResponse);
    }

    /// <summary>
    /// Permite a un usuario iniciar sesión en el sistema.
    /// </summary>
    /// <remarks>
    /// Este endpoint valida las credenciales del usuario proporcionadas en el cuerpo de la solicitud. 
    /// Si las credenciales son válidas, genera y devuelve un token de acceso junto con los datos del usuario.
    /// </remarks>
    /// <param name="userLoginRequestDto">Los datos de inicio de sesión del usuario, que incluyen email y contraseña.</param>
    /// <param name="cancellationToken">Token de cancelación para controlar la operación asincrónica.</param>
    /// <returns>Devuelve un objeto <see cref="UserLoginResponseDto"/> con el token de acceso y la información básica del usuario.</returns>
    /// <response code="200">Si las credenciales son válidas, devuelve el token de acceso</response>
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto userLoginRequestDto, CancellationToken cancellationToken)
    {
        UserLoginResponseDto userLoginResponseDto = await _authService.LoginUserAsync(userLoginRequestDto, cancellationToken);

        return Ok(userLoginResponseDto);
    }
}
