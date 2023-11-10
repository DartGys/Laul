using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using HeyRed.Mime;
using Laul.Application.Interfaces.BlobStorage;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace Laul.Infrastructure.Data.BlobStorage
{
    public class BlobStorageUpload : BlobStorageConnection, IBlobStorageUpload
    {
        public BlobStorageUpload() : base() { }
        
        public async Task<string> UploadFileAsync(byte[] fileBytes, string containerName, string fileName)
        {
            containerName = containerName.ToLower();
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            if (!containerClient.Exists())
            {
                // Якщо контейнер не існує, створюємо його
                containerClient.Create();
            }

            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            using (MemoryStream stream = new MemoryStream(fileBytes))
            {
                await blobClient.UploadAsync(stream, true);
            }

            var sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = fileName,
                Resource = "b",
                ExpiresOn = DateTimeOffset.UtcNow.AddYears(1),
                StartsOn = DateTimeOffset.UtcNow
            };

            string pattern = @"AccountName=([^;]+);AccountKey=([^;]+);";
            Match match = Regex.Match(connectionString, pattern);
            string accountName = match.Groups[1].Value;
            string accountKey = match.Groups[2].Value;

            var storageSharedKeyCredential = new StorageSharedKeyCredential(accountName, accountKey);

            sasBuilder.SetPermissions(BlobSasPermissions.Read);
            var sasToken = sasBuilder.ToSasQueryParameters(storageSharedKeyCredential).ToString();
            var blobUrlWithSasToken = blobClient.Uri + "?" + sasToken;

            return blobUrlWithSasToken;
        }
    }
}
