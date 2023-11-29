using IdentityServer4;
using Laul.Identity.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Laul.Identity.Services
{
    public static class ConfigureServices
    {
            public static IServiceCollection AddIndentityServices(this IServiceCollection services, IConfiguration configuration, string assembly)
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                services.AddDbContext<IdentityAspDbContext>(options =>
                options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly(assembly)));

                services.AddIdentity<IdentityUser, IdentityRole>()
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

                services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                })
                .AddGoogle(googleOptions =>
                {
                    googleOptions.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                });

                return services;
            }
    }
}
