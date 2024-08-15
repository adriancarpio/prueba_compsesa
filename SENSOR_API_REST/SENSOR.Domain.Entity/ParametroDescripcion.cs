using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENSOR.Domain.Entity
{
    public class ParametroDescripcion
    {
        public long Id { get; set; }
        public int CodigoParametro { get; set; }
        public string? DescripcionLarga { get; set; }
        public string? DescripcionMed { get; set; }
        public string? DescripcionCorta { get; set; }
        public string? Abreviacion { get; set; }
        public string? Observacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public char Estado { get; set; }
        public string? Unidad { get; set; }

        public ICollection<ParametroSensor>? ParametrosSensores { get; set; }
    }
}
