using Microsoft.Extensions.DependencyInjection;
using SENSOR.Application.Interface;
using SENSOR.Application.service;
using SENSOR.Persistence.EFCore;

namespace VENTA.Application
{
    public static class ConfigurateService
    {
        public static IServiceCollection ConfigurarAplicacion(this IServiceCollection services)
        {
            services.ConfigurationPersistenceEFCore();
            services.AddTransient<IConsultaService, ConsultaService>();
            return services;
        }
    }
}
