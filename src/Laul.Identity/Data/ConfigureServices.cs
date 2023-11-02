using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Laul.Identity.Data
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddIndentityServices(this IServiceCollection services, IConfiguration configuration, string assembly)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<IdentityAspDbContext>(options =>
            options.UseSqlServer(connectionString,
            b => b.MigrationsAssembly(assembly)));

            services.AddIdentity<IdentityUser,IdentityRole>()
                .AddEntityFrameworkStores<IdentityAspDbContext>();

            services.AddIdentityServer()
                .AddAspNetIdentity<IdentityUser>()
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

            services.AddAuthorization();

            return services;
        }
    }
}
