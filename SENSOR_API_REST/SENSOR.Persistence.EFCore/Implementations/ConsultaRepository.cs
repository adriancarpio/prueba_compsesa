using Npgsql;
using SENSOR.Domain.Entity;
using SENSOR.Domain.Interface;

using SENSOR.Persistence.EFCore.Extensions;

namespace SENSOR.Persistence.EFCore.Implementations
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly ApplicationDbContext _context;

        public ConsultaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DeviceData[]> GetDatosSensor(DateTime fechaDesde, DateTime fechaHasta, string modo)
        {
            string sql = string.Empty;
            var sqlParams = new[]
            {
                new NpgsqlParameter("fechaDesde", fechaDesde),
                new NpgsqlParameter("fechaHasta", fechaHasta)
            };

            if (modo == "day")
            {
                sql = @"
                    SELECT
                        ps.fecha_dato as FechaDato,
                        ps.codigo_parametro as CodigoParametro,
                        ps.nombre_parametro as NombreParametro,
                        pd.unidad as Unidad,
                        pd.abreviacion as Unidad,
                        AVG(ps.valor_numero) AS AvgData,
                        MIN(ps.valor_numero) AS MinData,
                        MAX(ps.valor_numero) AS MaxData
                    FROM
                        parametros_sensores ps
                    INNER JOIN
                        parametros_descripcion pd ON pd.id = ps.parametro_sensores_id
                    WHERE
                        ps.fecha_dato BETWEEN @fechaDesde AND @fechaHasta
                    GROUP BY
                        ps.fecha_dato, ps.codigo_parametro, ps.nombre_parametro, pd.unidad, pd.abreviacion
                    ORDER BY
                        ps.fecha_dato;
                ";
            } else if(modo == "month")
            {
                sql = @"
                   SELECT
                        DATE_TRUNC('month', ps.fecha_dato) AS FechaInicio,
                        (DATE_TRUNC('month', ps.fecha_dato) + INTERVAL '1 month - 1 day')::DATE AS FechaFin,
                        ps.codigo_parametro as CodigoParametro,
                        ps.nombre_parametro as NombreParametro,
                        pd.unidad as Unidad,
                        pd.abreviacion as Unidad,
                        AVG(ps.valor_numero) AS AvgData,
                        MIN(ps.valor_numero) AS MinData,
                        MAX(ps.valor_numero) AS MaxData
                    FROM
                        parametros_sensores ps
                    INNER JOIN
                        parametros_descripcion pd ON pd.id = ps.parametro_sensores_id
                    WHERE
                        ps.fecha_dato BETWEEN @fechaDesde AND @fechaHasta
                    GROUP BY
                        DATE_TRUNC('month', ps.fecha_dato), ps.codigo_parametro, ps.nombre_parametro, pd.unidad, pd.abreviacion
                    ORDER BY
                        FechaInicio;
                ";
            } else
            {
                throw new ArgumentException("Modo no valido. Solo se admiten 'day' o 'month'.");
            }

            var resultado = await _context.ExecuteQueryAsync<DeviceData>(sql, sqlParams);

            return resultado.ToArray();
        }
    }
}
