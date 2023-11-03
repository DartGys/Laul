

namespace Laul.WebAPI.Services
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.Authority = "https://localhost:5443";
                    options.ApiName = "WebAPI";
                });

            return services;
        }
    }
}
