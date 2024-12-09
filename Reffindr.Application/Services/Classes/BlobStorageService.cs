using Azure.Storage.Blobs;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Reffindr.Application.Services.Interfaces;

public class BlobStorageService : IBlobStorageService
{
    private readonly string? _connectionString;
    private readonly string? _containerName;

    public BlobStorageService(IConfiguration configuration)
    {
        _connectionString = configuration["AzureBlobStorage:ConnectionString"];
        _containerName = configuration["AzureBlobStorage:ContainerName"];
    }

    public async Task<string> UploadImageAsync(Stream fileStream, string fileName)
    {
        var blobContainerClient = new BlobContainerClient(_connectionString, _containerName);

        await blobContainerClient.CreateIfNotExistsAsync();

        var blobClient = blobContainerClient.GetBlobClient(fileName);
        await blobClient.UploadAsync(fileStream, true);

        return blobClient.Uri.ToString();
    }

    
}