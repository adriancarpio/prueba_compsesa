using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENSOR.Domain.Entity
{
    public class ParametroSensor
    {
        public long Id { get; set; }
        public int CodigoParametro { get; set; }
        public long ParametroSensoresId { get; set; }
        public string? NombreParametro { get; set; }
        public DateTime FechaDato { get; set; }
        public decimal ValorNumero { get; set; }

        public ParametroDescripcion? ParametrosDescripcion { get; set; }

    }

}
