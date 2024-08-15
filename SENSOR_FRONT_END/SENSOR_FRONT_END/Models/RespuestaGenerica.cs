using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENSOR.Dto
{
    public class RespuestaGenerica<T>
    {
        public bool esValida { get; set; }
        public string? mensaje { get; set; }
        public T? resultado { get; set; }
    }
}
