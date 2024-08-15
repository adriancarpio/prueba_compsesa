using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENSOR.Dto
{
    public class DeviceResponseDto
    {
        public List<string>? deviceDates { get; set; }
        public List<DeviceDataDto>? deviceData { get; set; }
    }
}
