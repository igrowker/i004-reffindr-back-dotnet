using Microsoft.AspNetCore.Http;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Infrastructure.Repositories.Interfaces;

public interface IImageRepository : IGenericRepository<Image>
{
}
