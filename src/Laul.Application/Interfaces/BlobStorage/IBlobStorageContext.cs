

namespace Laul.Application.Interfaces.BlobStorage
{
    public interface IBlobStorageContext
    {
        IBlobStorageUpload UploadAsync { get; }
        IBlobStorageDelete DeleteAsync { get; }
    }
}
