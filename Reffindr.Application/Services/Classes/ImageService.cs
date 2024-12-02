using Microsoft.AspNetCore.Http;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Application.Utilities.Mappers;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Response.User;

namespace Reffindr.Application.Services.Classes;

public class ImageService : IImageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ImageService
        (
            IUnitOfWork unitOfWork,
            IUserContext userContext,
            IHttpContextAccessor httpContextAccessor
            
        )
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<string>> UploadImagesAsync(List<IFormFile> images, CancellationToken cancellationToken)
    {
        List<string> imageUrls = new List<string>();
        var uploadsFolder = Path.Combine("wwwroot", "images");

        if (images != null && images.Any())
        {
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            foreach (var image in images)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await image.CopyToAsync(stream, cancellationToken);
                }

                var url = $"{_httpContextAccessor.HttpContext!.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
                imageUrls.Add((url + "/images/" + uniqueFileName).Replace("\\", "/"));
            }
        }

        return imageUrls;
    }




}
