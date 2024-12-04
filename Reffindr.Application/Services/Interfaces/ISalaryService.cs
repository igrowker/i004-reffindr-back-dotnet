using Reffindr.Domain.Models.UserModels;
using Reffindr.Shared.DTOs.Pagination;

namespace Reffindr.Application.Services.Interfaces;

public interface ISalaryService
{
    Task<List<Salary>> GetSalariesNameAsync(PaginationDto paginationDto);
}
