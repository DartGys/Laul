using System.IdentityModel.Tokens.Jwt;


namespace Laul.WebUI.Data
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = "https://localhost:5001";

                options.ClientId = "mvc";
                options.ClientSecret = "secret";
                options.ResponseType = "code";

                options.SaveTokens = true;
                options.Scope.Add("openid");
                options.Scope.Add("profile");
            });

            return services;
        }
    }
}
