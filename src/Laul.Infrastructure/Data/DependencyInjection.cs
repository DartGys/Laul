using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Laul.Application.Interfaces.Persistance;
using Laul.Infrastructure.Persistance;
using Laul.Application.Interfaces;
using Laul.Infrastructure.Data.BlobStorage;

namespace Laul.Infrastructure.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Реєстрація контексту бази даних
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString); // Використовуйте MSSQL
            });

            // Інші сервіси та налаштування
            // ...
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBlobStorageUpload, BlobStorageUpload>();

            return services;
        }
    }
}
