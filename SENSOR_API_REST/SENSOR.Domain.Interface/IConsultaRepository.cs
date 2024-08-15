using SENSOR.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENSOR.Domain.Interface
{
    public interface IConsultaRepository
    {
       Task<DeviceData[]> GetDatosSensor(DateTime fechaDesde, DateTime fechaHasta, string modo);
    }
}
