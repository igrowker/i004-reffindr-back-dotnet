﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Shared.DTOs.Request.Application;
using Reffindr.Shared.DTOs.Response.Application;

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

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetApplicationsByUserIdAsync(int userId)
        {
            var result = await _applicationService.GetApplicationsByUserIdAsync(userId);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result.Error });
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> PostApplication(ApplicationPostRequestDto applicationPostRequestDto, CancellationToken cancellationToken)
        {
            ApplicationPostResponseDto applicationResponse = await _applicationService.PostApplicationAsync(applicationPostRequestDto, cancellationToken);

            return Ok(applicationResponse);
        }
    }
}