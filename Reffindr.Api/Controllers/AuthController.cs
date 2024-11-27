using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Shared.DTOs.Request.Auth;
using Reffindr.Shared.DTOs.Request.User;
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
    /// Registrar un nuevo usuario en el sistema.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite la creación de un nuevo usuario. La contraseña del usuario se encripta utilizando SHA-256 antes de almacenarla en la base de datos.
    /// </remarks>
    /// <param name="userRegisterRequestDto">Los detalles de registro del usuario, que incluyen correo electrónico, rol, nombre y contraseña.</param>
    /// <param name="cancellationToken">El token de cancelación para la operación.</param>
    /// <returns>Devuelve un estado que indica si el registro fue exitoso o no.</returns>
    /// <response code="200">Si el usuario fue creado con éxito, devuelve isSucces=true; de lo contrario, devuelve isSucces=false.</response>

    [HttpPost]
    [Route("SignUp")]
    public async Task<IActionResult> SignUp([FromBody] UserRegisterRequestDto userRegisterRequestDto, CancellationToken cancellationToken)
    {
        UserRegisterResponseDto userRegisterResponse = await _authService.SignUpUserAsync(userRegisterRequestDto, cancellationToken);

        if (userRegisterResponse is null) return BadRequest("El email ya se encuentra registrado en nuestra base de datos.");

        return Ok(userRegisterResponse);
    }

    /// <summary>
    /// Iniciar sesión en el sistema.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite a un usuario autenticarse en el sistema utilizando sus credenciales. 
    /// Si las credenciales son válidas, se devuelve un token de acceso junto con información del usuario.
    /// </remarks>
    /// <param name="userLoginRequestDto">Objeto que contiene las credenciales del usuario, como el correo electrónico y la contraseña.</param>
    /// <param name="cancellationToken">Token de cancelación para la operación asíncrona.</param>
    /// <returns>Devuelve un objeto con la información del usuario autenticado y el token de acceso, si el inicio de sesión es exitoso.</returns>
    /// <response code="200">Si las credenciales son válidas, devuelve la respuesta del login con éxito.</response>
    /// <response code="401">Si las credenciales son incorrectas o no se encuentra el usuario, devuelve un error de autenticación.</response>
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto userLoginRequestDto, CancellationToken cancellationToken)
    {
        UserLoginResponseDto userLoginResponseDto = await _authService.LoginUserAsync(userLoginRequestDto, cancellationToken);

        return Ok(userLoginResponseDto);
    }

}
