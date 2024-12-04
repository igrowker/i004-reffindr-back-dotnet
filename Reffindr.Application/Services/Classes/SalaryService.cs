using Reffindr.Application.Services.Interfaces;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Pagination;

namespace Reffindr.Application.Services.Classes;

public class SalaryService : ISalaryService
{
    private readonly IUnitOfWork _unitOfWork;

    public SalaryService
    (
        IUnitOfWork unitOfWork
    )
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<List<Salary>> GetSalariesNameAsync(PaginationDto paginationDto)
    {
        return await _unitOfWork.SalaryRepository.GetAllWithPagination(paginationDto);
    }


}
