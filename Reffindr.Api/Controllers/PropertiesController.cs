using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Shared.DTOs.Filter;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Response.Property;

namespace Reffindr.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropertiesController : ControllerBase
{
    private readonly IPropertiesService _propertiesService;

    public PropertiesController
        (
            IPropertiesService propertiesService
        ) 
    {
        _propertiesService = propertiesService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetProperties([FromQuery] PropertyFilterDto filter)
    {
        var result = await _propertiesService.GetPropertiesAsync(filter);

        if (!result.IsSuccess)
        {
            return NotFound(new { Message = result.Error });
        }

        return Ok(result.Value);
    }

    [Authorize]
    [HttpPost]
    [Route("PostProperty")]
    public async Task<IActionResult> PostProperty([FromForm] PropertyPostRequestDto propertyPostRequestDto,  CancellationToken cancellationToken)
    {
        PropertyPostResponseDto propertyPostResponse = await _propertiesService.PostPropertyAsync(propertyPostRequestDto,  cancellationToken);

        if (propertyPostResponse is null) return BadRequest("No Pudo Crearse");

        return Ok(propertyPostResponse);
    }
}
