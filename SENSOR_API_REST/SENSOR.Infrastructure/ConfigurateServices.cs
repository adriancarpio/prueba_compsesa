using Microsoft.Extensions.DependencyInjection;
using SENSOR.Persistence.EFCore;

namespace SENSOR.Infrastructure
{
    public static class ConfigurateServices
    {
        public static IServiceCollection ConfigurarInfraestructura(this IServiceCollection services)
        {
            services.ConfigurationPersistenceEFCore();
            return services;
        }

    }
}
