using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENSOR.Domain.Entity
{
    public class DeviceData
    {
        public DateTime FechaDato { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CodigoParametro { get; set; }
        public string? NombreParametro { get; set; }
        public string? Unidad { get; set; }
        public string? Abreviacion { get; set; }
        public decimal AvgData { get; set; }
        public decimal MinData { get; set; }
        public decimal MaxData { get; set; }
    }
}
