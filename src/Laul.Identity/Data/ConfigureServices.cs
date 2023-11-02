using Microsoft.EntityFrameworkCore;

namespace Laul.Identity.Data
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddIndentityServices(this IServiceCollection services, IConfiguration configuration, string assembly)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddIdentityServer()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b =>
                    b.UseSqlServer(connectionString, opt => opt.MigrationsAssembly(assembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b =>
                    b.UseSqlServer(connectionString, opt => opt.MigrationsAssembly(assembly));
                })
                .AddDeveloperSigningCredential();

            return services;
        }
    }
}
