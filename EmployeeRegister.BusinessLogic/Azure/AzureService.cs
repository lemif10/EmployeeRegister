using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Options;

namespace EmployeeRegister.BusinessLogic.Azure
{
    public class AzureService : IAzureService

    {
    private readonly AzureSettings _azureSettings;

    public AzureService(AzureSettings azureSettings)
    {
        _azureSettings = azureSettings;
    }

    public async Task<List<string>> GetImageUrls()
    {
        List<string> imageUrls = new List<string>();

        BlobServiceClient blobServiceClient = new BlobServiceClient(_azureSettings.ConnectionString);

        BlobContainerClient blobContainerClient =
            blobServiceClient.GetBlobContainerClient(_azureSettings.ImageContainerName);

        if (blobContainerClient.Exists())
        {
            foreach (BlobItem blobItem in blobContainerClient.GetBlobs())
            {
                imageUrls.Add(blobContainerClient.Uri + "/" + blobItem.Name);
            }
        }

        return await Task.FromResult(imageUrls);
    }
    }
}