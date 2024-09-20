using InfoTech.Application;
using InfoTech.Core;
using InfoTech.Infrastructure;

namespace InfoTech.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfoTechDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI()
                .AddCoreDI(configuration);

            return services;
        }
    }
}
