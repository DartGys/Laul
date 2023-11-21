using Microsoft.Extensions.DependencyInjection;
using Laul.Application.Common.Mapping;

namespace Laul.Application.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddAutoMapper(typeof(AssemblyMappingProfile).Assembly); 

            return services;
        }
    }
}
