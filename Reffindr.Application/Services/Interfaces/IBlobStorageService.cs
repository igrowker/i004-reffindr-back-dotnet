using Reffindr.Domain.Models;
using Reffindr.Shared.DTOs.Request.Application;
using Reffindr.Shared.DTOs.Response.Application;
using Reffindr.Shared.Result;

namespace Reffindr.Application.Services.Interfaces
{
    public interface IBlobStorageService
    {
        Task<string> UploadImageAsync(Stream fileStream, string fileName);
    }
}
