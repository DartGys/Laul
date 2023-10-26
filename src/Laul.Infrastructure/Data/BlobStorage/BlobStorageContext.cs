using Laul.Application.Interfaces.BlobStorage;


namespace Laul.Infrastructure.Data.BlobStorage
{
    public class BlobStorageContext : IBlobStorageContext
    {
        public BlobStorageContext() 
        {
            UploadAsync = new BlobStorageUpload();
            DeleteAsync = new BlobStorageDelete();
        }

        public IBlobStorageUpload UploadAsync { get; private set; }

        public IBlobStorageDelete DeleteAsync { get; private set; }
    }
}
