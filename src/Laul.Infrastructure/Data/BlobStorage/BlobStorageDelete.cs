using Azure;
using Azure.Storage.Blobs;
using Laul.Application.Common.Parser;
using Laul.Application.Interfaces.BlobStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Infrastructure.Data.BlobStorage
{
    public class BlobStorageDelete : BlobStorageConnection, IBlobStorageDelete
    {
        public BlobStorageDelete() : base() { }
        public async Task<bool> DeleteFileAsync(string token)
        {
            string containerName = TokenParser.ParsToken(token).containerName;
            string fileName = TokenParser.ParsToken(token).fileName;

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            // Отримуємо контейнер
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // Отримуємо BlobClient для видалення
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            Response<bool> response = await blobClient.DeleteIfExistsAsync();

            return response;
        }
    }
}
