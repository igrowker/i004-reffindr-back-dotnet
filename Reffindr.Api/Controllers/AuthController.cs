using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reffindr.Application.Services.Classes;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Domain.Models;
using Reffindr.Infrastructure.Data;
using Reffindr.Shared.DTOs.Request.Auth;
using Reffindr.Shared.DTOs.Request.User;
using Reffindr.Shared.DTOs.Response.Auth;
using System.Threading.Tasks;

namespace Reffindr.Api.Controllers
{
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

            return Ok(userRegisterResponse);
        }

        ///// <summary>
        ///// Log in a user and generate a JWT token.
        ///// </summary>
        ///// <remarks>
        ///// This endpoint allows an existing user to log in. If the user credentials are valid, a JWT token is generated and returned.
        ///// </remarks>
        ///// <param name="user">The user login details including email and password.</param>
        ///// <returns>Returns a status indicating whether the login was successful, along with a JWT token if successful.</returns>
        ///// <response code="200">If the login is successful, returns isSucces=true and a JWT token; otherwise, returns isSucces=false with an empty token.</response>
        //[HttpPost]
        //[Route("LogIn")]
        //public async Task<IActionResult> LogIn ([FromBody] UserRequestDto user)
        //{
        //    var foundUser = await _context.User.Where(x => x.email == user.email && x.password == _utilities.encriptedSha256(user.password)).FirstOrDefaultAsync();
        //    if(foundUser == null)
        //        return StatusCode(StatusCodes.Status200OK, new { isSucces = false, token = "" });
        //    else
        //        return StatusCode(StatusCodes.Status200OK, new { isSucces = true, token = _utilities.generateJWT(foundUser)});
        //}


        ///// <summary>
        ///// Verifica la conexión a la base de datos.
        ///// </summary>
        ///// <remarks>
        ///// Este endpoint se puede usar para verificar si la conexión a la base de datos es exitosa.
        ///// Devuelve un mensaje indicando el estado de la conexión.
        ///// </remarks>
        ///// <returns>
        ///// 200 OK si la conexión fue exitosa.
        ///// 500 Internal Server Error si ocurre un problema al intentar conectarse.
        ///// </returns>
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        //[HttpGet("test_connection")]
        //public async Task<IActionResult> TestConnection()
        //{
        //    try
        //    {
        //        var usersss = await _context.User.ToListAsync();
        //        return Ok(usersss);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error al acceder a la tabla: {ex.Message}");
        //    }
        //}

    }
}
