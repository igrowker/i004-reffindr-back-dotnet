using Microsoft.EntityFrameworkCore;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;

namespace Reffindr.Infrastructure.Repositories.Classes;

public class GenreRepository : GenericRepository<Genre> , IGenreRepository
{
    public GenreRepository(ApplicationDbContext options) : base(options)
    {
        
    }

}
