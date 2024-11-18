using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reffindr.Application.Services.Classes;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Shared.DTOs.Request.Auth;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Response.Auth;
using Reffindr.Shared.DTOs.Response.Property;
using System.Security.Claims;

namespace Reffindr.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropertiesController : ControllerBase
{
    private readonly IPropertiesService _propertiesService;
    private readonly IUsersService _usersService;

    public PropertiesController
        (
            IPropertiesService propertiesService,
            IUsersService usersService
        ) 
    {
        _propertiesService = propertiesService;
        _usersService = usersService;
    }
        
    [Authorize]
    [HttpPost]
    [Route("PostProperty")]
    public async Task<IActionResult> PostProperty([FromBody] PropertyPostRequestDto propertyPostRequestDto, CancellationToken cancellationToken)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdString))
        {
            return Unauthorized("No se pudo determinar el identificador del usuario.");
        }

        PropertyPostResponseDto propertyPostResponse = await _propertiesService.PostPropertyAsync(propertyPostRequestDto, cancellationToken);

        if (propertyPostResponse is null) return BadRequest("");

        return Ok(propertyPostResponse);
    }
}
