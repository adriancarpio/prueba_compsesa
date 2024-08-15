namespace SENSOR_FRONT_END.Models
{
    public class DashboardViewModel
    {
        public List<string>? DeviceDates { get; set; }
        public List<SensorData>? TemperatureData { get; set; }
        public List<SensorData>? HumidityData { get; set; }
        public List<SensorData>? RadiationData { get; set; }
    }

    public class SensorData
    {
        public double Avg { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
    }
}
