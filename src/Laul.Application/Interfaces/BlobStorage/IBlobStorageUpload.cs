using Microsoft.AspNetCore.Http;

namespace Laul.Application.Interfaces.BlobStorage
{
    public interface IBlobStorageUpload
    {
        public Task<string> UploadFileAsync(IFormFile imageFile, string name);
    }
}
