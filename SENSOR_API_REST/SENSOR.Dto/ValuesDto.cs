using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENSOR.Dto
{
    public class ValuesDto
    {
        public List<double>? AvgData { get; set; }
        public List<double>? MinData { get; set; }
        public List<double>? MaxData { get; set; }
    }
}
