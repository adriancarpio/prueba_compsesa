using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENSOR.Dto
{
    public class ValuesDto
    {
        public List<double>? avgData { get; set; }
        public List<double>? minData { get; set; }
        public List<double>? maxData { get; set; }
    }
}
