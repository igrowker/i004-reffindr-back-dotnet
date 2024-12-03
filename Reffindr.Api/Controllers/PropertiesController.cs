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
    private readonly IFavoriteService _favoriteService;

    public PropertiesController
        (
            IPropertiesService propertiesService,
            IFavoriteService favoriteService
        ) 
    {
        _propertiesService = propertiesService;
        _favoriteService = favoriteService;
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

    [Authorize]
    [HttpGet]
    [Route("GetFavoriteProperties")]
    public async Task<IActionResult> GetFavoriteProperties(int userId)
    {
        List<PropertyGetResponseDto> favoriteProperties = await _favoriteService.GetFavorites(userId);

        if (favoriteProperties is null) return NotFound();

        return Ok(favoriteProperties);
    }

    [Authorize]
    [HttpPost]
    [Route("AddFavorite")]
    public async Task<IActionResult> AddFavorite(int userId, int propertyId, CancellationToken cancellationToken)
    {
        await _favoriteService.AddFavorite(userId, propertyId, cancellationToken);
        return Ok();
    }

    [Authorize]
    [HttpPost]
    [Route("RemoveFavorite")]
    public async Task<IActionResult> RemoveFavorite(int userId, int propertyId, CancellationToken cancellationToken)
    {
        await _favoriteService.RemoveFavorite(userId, propertyId, cancellationToken);
        return Ok();
    }
}
