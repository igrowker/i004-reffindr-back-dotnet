using Microsoft.AspNetCore.Http;
using Reffindr.Shared.DTOs.Response.User;

namespace Reffindr.Application.Services.Interfaces;

public interface IImageService
{
    Task<List<string>> UploadImagesAsync(List<IFormFile> images, CancellationToken cancellationToken);
    Task<string> UploadImagesAsync(IFormFile image);

}
