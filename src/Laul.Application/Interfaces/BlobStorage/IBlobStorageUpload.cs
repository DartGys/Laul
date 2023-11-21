using Microsoft.AspNetCore.Http;

namespace Laul.Application.Interfaces.BlobStorage
{
    public interface IBlobStorageUpload
    {
        public Task<string> UploadFileAsync(byte[] imageFile, string containerName,string fileName);
    }
}
