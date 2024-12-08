using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Shared.DTOs.Filter;
using Reffindr.Shared.DTOs.Pagination;
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

    [HttpGet]
    [Route("GetProperties")]
    public async Task<IActionResult> GetProperties([FromQuery] PropertyFilterDto filter, [FromQuery] PaginationDto paginationDto)
    {
        var result = await _propertiesService.GetPropertiesAsync(filter, paginationDto);

        return Ok(result);
    }

    [HttpGet]
    [Route("GetProperty/{id:int}")]
    public async Task<IActionResult> GetProperty(int id)
    {
        PropertyGetResponseDto propertyResponse = await _propertiesService.GetPropertyAsync(id);

        return Ok(propertyResponse);
    }

    /// <summary>
    /// IInquilo Saliente Crea Propiedad y Envia Notificacion al Owner
    /// </summary>
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
    public async Task<IActionResult> GetFavoriteProperties()
    {
        List<PropertyGetResponseDto> favoriteProperties = await _favoriteService.GetFavorites();

        if (favoriteProperties is null) return NotFound();

        return Ok(favoriteProperties);
    }

    [Authorize]
    [HttpPost]
    [Route("AddFavorite")]
    public async Task<IActionResult> AddFavorite(int propertyId, CancellationToken cancellationToken)
    {
        await _favoriteService.AddFavorite(propertyId, cancellationToken);
        return Ok();
    }

    [Authorize]
    [HttpPost]
    [Route("RemoveFavorite")]
    public async Task<IActionResult> RemoveFavorite(int propertyId, CancellationToken cancellationToken)
    {
        await _favoriteService.RemoveFavorite(propertyId, cancellationToken);
        return Ok();
    }


    /// <summary>
    /// Owner Acepta Propiedad y envia Notificacion a Inquilino Saliente
    /// </summary>
    [Authorize]
    [HttpPatch]
    [Route("ConfirmProperty")]
    public async Task<IActionResult> ConfirmProperty(PropertyPatchRequestDto propertyPatchRequestDto, CancellationToken cancellationToken)
    {
        var response = await  _propertiesService.ConfirmProperty(propertyPatchRequestDto, cancellationToken);
        return Ok(response);
    }
	[Authorize]
	[HttpDelete]
	[Route("DeleteProperty")]
	public async Task<IActionResult> DeleteProperty(int propertyId, CancellationToken cancellationToken)
	{
		PropertyDeleteResponseDto response = await _propertiesService.DeletePropertyAsync(propertyId, cancellationToken);
		return Ok(response);
	}

}
