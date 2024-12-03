using Microsoft.AspNetCore.Http;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Application.Utilities.Mappers;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Response.User;
using Azure.Storage.Blobs;

namespace Reffindr.Application.Services.Classes;

public class ImageService : IImageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IBlobStorageService _blobStorageService;

    public ImageService
        (
            IUnitOfWork unitOfWork,
            IUserContext userContext,
            IHttpContextAccessor httpContextAccessor,
            IBlobStorageService blobStorageService


        )
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
        _httpContextAccessor = httpContextAccessor;
        _blobStorageService = blobStorageService;
    }

    public async Task<List<string>> UploadImagesAsync(List<IFormFile> images, CancellationToken cancellationToken)
    {
        List<string> imageUrls = new List<string>();

        if (images != null && images.Any())
        {
            foreach (var image in images)
            {
                using (var stream = image.OpenReadStream())
                {
                    var uniqueFileName = (Guid.NewGuid().ToString() + "_" + image.FileName).Replace(" ", "");

                    var imageUrl = await _blobStorageService.UploadImageAsync(stream, uniqueFileName);
                    imageUrls.Add(imageUrl);
                }
            }
        }

        return imageUrls;
    }

    public async Task<string> UploadImagesAsync(IFormFile image)
    {
                using (var stream = image.OpenReadStream())
                {
                    var uniqueFileName = (Guid.NewGuid().ToString() + "_" + image.FileName).Replace(" ", ""); ;
                    var imageUrl = await _blobStorageService.UploadImageAsync(stream, uniqueFileName);
                    return imageUrl;
                }
    }





}
