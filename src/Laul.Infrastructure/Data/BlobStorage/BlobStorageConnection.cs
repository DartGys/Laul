using Microsoft.Extensions.Configuration;
#nullable disable

namespace Laul.Infrastructure.Data.BlobStorage
{
    public abstract class BlobStorageConnection
    {
        public readonly string connectionString;
        public BlobStorageConnection()
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile($"C:\\Users\\ZenBook\\source\\repos\\Laul\\src\\Laul.Infrastructure\\Data\\BlobStorage\\key.json")
            .Build();

            connectionString = config["AzureStorageConnectionString"];
        }
    }
}
