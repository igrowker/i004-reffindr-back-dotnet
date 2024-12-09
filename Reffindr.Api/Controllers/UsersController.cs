using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Shared.DTOs.Pagination;
using Reffindr.Shared.DTOs.Response.Property;
using Reffindr.Shared.DTOs.Response.User;

namespace Reffindr.Api.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IPropertiesService _propertiesService;

    public UsersController
        (
            IUserService userService,
            IPropertiesService propertiesService
        )
    {
        _userService = userService;
        _propertiesService = propertiesService;
    }

  
    [Authorize]
    [HttpGet]
    [Route("get-credentials")]
    public async Task<IActionResult> GetUserCredential()
    {
        UserCredentialsResponseDto userCredentialsResponseDto = await _userService.GetUserCredentialsAsync();

        return Ok(userCredentialsResponseDto);
    }

    /// <summary>
    /// Actualiza la información de un usuario.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite actualizar los datos de un usuario existente. 
    /// Se requiere autorización para acceder a este recurso.
    /// </remarks>
    /// <param name="userUpdateRequestDto">
    /// Un objeto de tipo <see cref="UserUpdateRequestDto"/> que contiene los datos actualizados del usuario.
    /// </param>
    /// <param name="cancellationToken">
    /// Un token para cancelar la operación de actualización si es necesario.
    /// </param>
    /// <returns>
    /// Devuelve un objeto <see cref="UserUpdateResponseDto"/> con los detalles actualizados del usuario.
    /// Si ocurre un error, se devolverá un código de estado HTTP correspondiente.
    /// </returns>
    /// <response code="200">El usuario fue actualizado exitosamente.</response>
    /// <response code="400">El cuerpo de la solicitud no es válido.</response>
    /// <response code="401">El usuario no está autorizado para realizar esta acción.</response>
    /// <response code="404">No se encontró el usuario especificado.</response>
    /// <response code="500">Ocurrió un error interno en el servidor.</response>
    [Authorize]
    [HttpPut]
    [Route("modify-credentials")]
    public async Task<IActionResult> UpdateUser([FromForm] UserUpdateRequestDto userUpdateRequestDto, CancellationToken cancellationToken)
    {
        UserUpdateResponseDto userResponseDto = await _userService.UpdateUserAsync(userUpdateRequestDto, cancellationToken);
        return Ok(userResponseDto);
    }

    [Authorize]
    [HttpGet("get-ownerProperties")]
    public async Task<IActionResult> GetOwnerProperties()
    {
        List<PropertyGetResponseDto> ownerProperties = await _propertiesService.GetOwnerPropertiesAsync();

        return Ok(ownerProperties);
    }

    [Authorize]
    [HttpGet("get-tenantAnnounce")]
    public async Task<IActionResult> GetTenantAnnounce()
    {
        List<PropertyGetResponseDto> ownerProperties = await _propertiesService.GetTenantAnnounceAsync();

        return Ok(ownerProperties);
    }
}
