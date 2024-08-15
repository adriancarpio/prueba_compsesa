using Microsoft.EntityFrameworkCore;
using SENSOR.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENSOR.Persistence.EFCore.Configurations
{
    public static class ParametroDescripcionConfiguration
    {
        public static void Configurar(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParametroDescripcion>(entity =>
            {
                entity.ToTable("parametros_descripcion");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.CodigoParametro)
                    .HasColumnName("codigo_parametro");

                entity.Property(e => e.DescripcionLarga)
                    .HasColumnName("descripcion_larga")
                    .HasMaxLength(255);

                entity.Property(e => e.DescripcionMed)
                    .HasColumnName("descripcion_med")
                    .HasMaxLength(255);

                entity.Property(e => e.DescripcionCorta)
                    .HasColumnName("descripcion_corta")
                    .HasMaxLength(100);

                entity.Property(e => e.Abreviacion)
                    .HasColumnName("abreviacion")
                    .HasMaxLength(50);

                entity.Property(e => e.Observacion)
                    .HasColumnName("observacion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fecha_modificacion");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(1);

                entity.Property(e => e.Unidad)
                    .HasColumnName("unidad")
                    .HasMaxLength(50);

                entity.HasMany(d => d.ParametrosSensores)
                  .WithOne(e => e.ParametrosDescripcion)
                  .HasForeignKey(e => e.ParametroSensoresId);
            });
        }
    }
}
