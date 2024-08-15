using Microsoft.Extensions.DependencyInjection;
using SENSOR.Domain.Interface;
using SENSOR.Persistence.EFCore.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENSOR.Persistence.EFCore
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigurationPersistenceEFCore(this IServiceCollection services)
        {
            services.AddTransient<IConsultaRepository, ConsultaRepository>();

            return services;
        }
    }
}
