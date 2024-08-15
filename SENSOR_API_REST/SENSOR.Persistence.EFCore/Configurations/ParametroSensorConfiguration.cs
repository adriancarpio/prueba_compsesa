using Microsoft.EntityFrameworkCore;
using SENSOR.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENSOR.Persistence.EFCore.Configurations
{
    public static class ParametroSensorConfiguration
    {
        public static void Configurar(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParametroSensor>(entity =>
            {
                entity.ToTable("parametros_sensores");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.CodigoParametro)
                    .HasColumnName("codigo_parametro");

                entity.Property(e => e.ParametroSensoresId)
                    .HasColumnName("parametro_sensores_id");

                entity.Property(e => e.NombreParametro)
                    .HasColumnName("nombre_parametro")
                    .HasMaxLength(255);

                entity.Property(e => e.FechaDato)
                    .HasColumnName("fecha_dato");

                entity.Property(e => e.ValorNumero)
                    .HasColumnName("valor_numero");

                entity.HasOne(e => e.ParametrosDescripcion)
                  .WithMany(d => d.ParametrosSensores)
                  .HasForeignKey(e => e.ParametroSensoresId);
            });
        }
    }
}
