using SENSOR.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VENTA.Dto;

namespace SENSOR.Application.Interface
{
    public interface IConsultaService
    {
        Task<RespuestaGenerica<DeviceResponseDto>> GetDatosSensor(DateTime fechaDesde, DateTime fechaHasta, string modo);
    }
}
