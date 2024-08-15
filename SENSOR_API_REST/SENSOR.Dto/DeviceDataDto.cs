using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENSOR.Dto
{
    public class DeviceDataDto
    {
        public string? CodigoParametro { get; set; }
        public string? NombreParametro { get; set; }
        public string? UnidadParametro { get; set; }
        public string? AbreviacionParametro { get; set; }
        public ValuesDto? Values { get; set; }
    }
}
