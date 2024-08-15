using Microsoft.AspNetCore.Mvc;
using SENSOR.Dto;
using SENSOR_FRONT_END.Models;
using SENSOR_FRONT_END.Servicios;
using System.Diagnostics;
using System.Text.Json;

namespace SENSOR_FRONT_END.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiService _apiService;


        public HomeController(ApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> Index(string fechaDesde = "2024-04-01", string fechaHasta = "2024-05-31",string modo = "day")
        {
            var data = await _apiService.GetSensorData($"api/Consulta/{fechaDesde}/{fechaHasta}/{modo}");

            var deviceDates = data.deviceDates;

            var temperatureData = MapSensorData(data.deviceData!, "Temperatura");
            var humidityData = MapSensorData(data.deviceData!, "Humedad");
            var radiationData = MapSensorData(data.deviceData!, "Radiacion solar");

            var viewModel = new DashboardViewModel
            {
                DeviceDates = deviceDates,
                TemperatureData = temperatureData,
                HumidityData = humidityData,
                RadiationData = radiationData
            };

            ViewData["TemperatureData"] = JsonSerializer.Serialize(viewModel.TemperatureData);
            ViewData["HumidityData"] = JsonSerializer.Serialize(viewModel.HumidityData);
            ViewData["RadiationData"] = JsonSerializer.Serialize(viewModel.RadiationData);
            ViewData["DeviceDates"] = JsonSerializer.Serialize(viewModel.DeviceDates);

            return View(viewModel);
        }

        private List<SensorData> MapSensorData(IEnumerable<DeviceDataDto> deviceData, string parametro)
        {
            var sensorDataDto = deviceData.FirstOrDefault(d => d.nombreParametro == parametro)?.values;

            if (sensorDataDto == null)
            {
                return new List<SensorData>();
            }

            // Asegúrate de que la longitud de avgData, minData y maxData sean iguales
            var count = sensorDataDto.avgData?.Count ?? 0;

            return Enumerable.Range(0, count)
                .Select(i => new SensorData
                {
                    Avg = sensorDataDto.avgData?[i] ?? 0,
                    Min = sensorDataDto.minData?[i] ?? 0,
                    Max = sensorDataDto.maxData?[i] ?? 0
                })
                .ToList();
        }
    }
}
