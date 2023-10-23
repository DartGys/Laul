using Microsoft.AspNetCore.Http;

namespace Laul.Application.Interfaces
{
    public interface IBlobStorageUpload
    {
        public Task<string> UploadFileAsync(IFormFile imageFile, string name);
    }
}
