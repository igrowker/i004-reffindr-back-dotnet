using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Shared.DTOs.Pagination;

namespace Reffindr.Api.Controllers;

[Route("api/[Controller]")]
[AllowAnonymous]
[ApiController]
public class SalariesController : ControllerBase
{
    private readonly ISalaryService _salaryService;
    private readonly IPropertiesService _propertiesService;

    public SalariesController
        (
            ISalaryService userService,
            IPropertiesService propertiesService
        )
    {
        _salaryService = userService;
        _propertiesService = propertiesService;
    }

    [HttpGet("getSalaries")]
    public async Task<IActionResult> GetSalaries([FromQuery]PaginationDto paginationDto)
    {
        var tenantSalaries = await _salaryService.GetSalariesNameAsync(paginationDto);

        return Ok(tenantSalaries);
    }
}
