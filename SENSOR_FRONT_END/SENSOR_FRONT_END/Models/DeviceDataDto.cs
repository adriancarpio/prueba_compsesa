using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENSOR.Dto
{
    public class DeviceDataDto
    {
        public string? codigoParametro { get; set; }
        public string? nombreParametro { get; set; }
        public string? unidadParametro { get; set; }
        public string? abreviacionParametro { get; set; }
        public ValuesDto? values { get; set; }
    }
}
