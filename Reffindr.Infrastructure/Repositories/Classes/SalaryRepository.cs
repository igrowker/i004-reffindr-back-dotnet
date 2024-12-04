using Microsoft.EntityFrameworkCore;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;

using Reffindr.Shared.DTOs.Pagination;
using Reffindr.Shared.IQueryableExtensions;


namespace Reffindr.Infrastructure.Repositories.Classes;

public class SalaryRepository : GenericRepository<Salary>, ISalaryRepository
{
    public SalaryRepository(ApplicationDbContext options) : base(options)
    {
        
    }

}
