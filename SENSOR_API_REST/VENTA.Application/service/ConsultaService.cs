using SENSOR.Application.Interface;
using SENSOR.Domain.Interface;
using SENSOR.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VENTA.Dto;

namespace SENSOR.Application.service
{
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository repository;

        public ConsultaService(IConsultaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<RespuestaGenerica<DeviceResponseDto>> GetDatosSensor(DateTime fechaDesde, DateTime fechaHasta, string modo)
        {
            try
            {
                var respuesta = await repository.GetDatosSensor(fechaDesde, fechaHasta, modo);

                var response = new DeviceResponseDto
                {
                    DeviceDates = new List<string>(),
                    DeviceData = new List<DeviceDataDto>()
                };

                var groupedData = respuesta
                    .GroupBy(d => new { d.CodigoParametro, d.NombreParametro, d.Unidad, d.Abreviacion })
                    .ToList();

                if (modo == "day")
                {
                    response.DeviceDates = respuesta
                        .Select(d => d.FechaDato.ToString("yyyy-MM-dd"))
                        .Distinct()
                        .ToList();

                    foreach (var group in groupedData)
                    {
                        var deviceDataDto = new DeviceDataDto
                        {
                            CodigoParametro = group.Key.CodigoParametro.ToString(),
                            NombreParametro = group.Key.NombreParametro,
                            UnidadParametro = group.Key.Unidad,
                            AbreviacionParametro = group.Key.Abreviacion,
                            Values = new ValuesDto
                            {
                                AvgData = group.Select(d => (double)d.AvgData).ToList(),
                                MinData = group.Select(d => (double)d.MinData).ToList(),
                                MaxData = group.Select(d => (double)d.MaxData).ToList()
                            }
                        };

                        response.DeviceData.Add(deviceDataDto);
                    }
                }
                else if (modo == "month")
                {
                    DateTime startMonth = new DateTime(fechaDesde.Year, fechaDesde.Month, 1);
                    DateTime endMonth = new DateTime(fechaHasta.Year, fechaHasta.Month, DateTime.DaysInMonth(fechaHasta.Year, fechaHasta.Month));

                    var monthRanges = new List<string>();

                    for (var date = startMonth; date <= endMonth; date = date.AddMonths(1))
                    {
                        var startOfMonth = date.ToString("yyyy-MM-01");
                        var endOfMonth = date.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
                        monthRanges.Add($"{startOfMonth} – {endOfMonth}");
                    }

                    response.DeviceDates = monthRanges;

                    foreach (var group in groupedData)
                    {
                        var deviceDataDto = new DeviceDataDto
                        {
                            CodigoParametro = group.Key.CodigoParametro.ToString(),
                            NombreParametro = group.Key.NombreParametro,
                            UnidadParametro = group.Key.Unidad,
                            AbreviacionParametro = group.Key.Abreviacion,
                            Values = new ValuesDto
                            {
                                AvgData = group.Select(d => (double)d.AvgData).ToList(),
                                MinData = group.Select(d => (double)d.MinData).ToList(),
                                MaxData = group.Select(d => (double)d.MaxData).ToList()
                            }
                        };

                        response.DeviceData.Add(deviceDataDto);
                    }
                }

                return RespuestaGenerica<DeviceResponseDto>.RespuestaExito(response);
            }
            catch
            {
                return RespuestaGenerica<DeviceResponseDto>.RespuestaError("Ha Ocurrido una Excepción");
            }
        }
    }
}
