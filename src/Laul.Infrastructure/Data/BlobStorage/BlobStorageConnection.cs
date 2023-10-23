using Microsoft.Extensions.Configuration;

namespace Laul.Infrastructure.Data.BlobStorage
{
    public abstract class BlobStorageConnection
    {
        public readonly string connectionString;
        public BlobStorageConnection()
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("C:\\Users\\boda2\\source\\repos\\Laul\\src\\Laul.Infrastructure\\Data\\BlobStorage\\key.json")
            .Build();

            connectionString = config["AzureStorageConnectionString"];
        }
    }
}
