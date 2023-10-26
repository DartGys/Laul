using Azure;
using Azure.Storage.Blobs;
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
        public async Task<bool> DeleteFileAsync(string name)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            string imgContainer = "image";
            // Отримуємо контейнер
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(imgContainer);

            // Отримуємо BlobClient для видалення
            BlobClient blobClient = containerClient.GetBlobClient(name);

            Response<bool> response = await blobClient.DeleteIfExistsAsync();

            return response;
        }
    }
}
