using Laul.WebUI.Common.Mapping;
using Laul.WebUI.Services.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.IdentityModel.Tokens.Jwt;


namespace Laul.WebUI.Services
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IdentityServerSettings>(configuration.GetSection(
                nameof(IdentityServerSettings)));
            services.AddScoped<ITokenService, TokenService>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect(
                OpenIdConnectDefaults.AuthenticationScheme,
                options =>
                {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.SignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
                    options.Authority = configuration["InteractiveServiceSettings:AuthorityUrl"];
                    options.ClientId = configuration["InteractiveServiceSettings:ClientId"];
                    options.ClientSecret = configuration["InteractiveServiceSettings:ClientSecret"];

                    options.ResponseType = "code";
                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;
                }
            );

            services.AddAutoMapper(typeof(AssemblyMappingProfile).Assembly);

            return services;
        }
    }
}
