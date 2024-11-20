using Reffindr.Domain.Models;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;

namespace Reffindr.Infrastructure.Repositories.Classes;

public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
{
    public CandidateRepository(ApplicationDbContext dbContext) : base(dbContext)   
    {
        
    }
}
