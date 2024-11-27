using Microsoft.AspNetCore.Mvc;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Shared.DTOs.Response.Property;

namespace Reffindr.Api.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("get-ownerProperties")]
    public async Task<IActionResult> GetOwnerProperties()
    {
        List<PropertyGetResponseDto> ownerProperties = await _userService.GetOwnerPropertiesAsync();

        return Ok(ownerProperties);
    }
}
