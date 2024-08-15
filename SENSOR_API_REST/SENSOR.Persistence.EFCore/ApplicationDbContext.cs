using Microsoft.EntityFrameworkCore;
using SENSOR.Domain.Entity;
using SENSOR.Persistence.EFCore.Configurations;

namespace SENSOR.Persistence.EFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<ParametroSensor> ParametrosSensores { get; set; }
        public DbSet<ParametroDescripcion> ParametrosDescripcion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ParametroSensorConfiguration.Configurar(modelBuilder);
            ParametroDescripcionConfiguration.Configurar(modelBuilder);
        }

    }
}
