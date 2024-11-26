using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Shared.DTOs.Request.Application;
using Reffindr.Shared.DTOs.Response.Application;
using Reffindr.Shared.Result;

namespace Reffindr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetApplicationsByUserIdAsync(int userId)
        {
            var result = await _applicationService.GetApplicationsByUserIdAsync(userId);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result.Error });
            }

            return Ok(result.Value);
        }

        [HttpGet("Property/{propertyId}")]
        public async Task<IActionResult> GetApplicationsByPropertyIdAsync(int propertyId)
        {
            List<ApplicationGetResponseDto> applications = await _applicationService.GetApplicationsByPropertyIdAsync(propertyId);

            return Ok(applications);
        }

        [HttpPost]
        public async Task<IActionResult> PostApplication(ApplicationPostRequestDto applicationPostRequestDto, CancellationToken cancellationToken)
        {

            Result<ApplicationPostResponseDto> result = await _applicationService.PostApplicationAsync(applicationPostRequestDto, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result.Error });
            }

            return Ok(result.Value);
        }
    }
}
