using SENSOR.Dto;
using System.Text.Json;
using SENSOR.Dto;

namespace SENSOR_FRONT_END.Servicios
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DeviceResponseDto> GetSensorData(string endpoint)
        {
            string jsonString = string.Empty;
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            jsonString = await response.Content.ReadAsStringAsync();
            var respuesta = JsonSerializer.Deserialize<RespuestaGenerica<DeviceResponseDto>>(jsonString);
            bool esValida = respuesta!.esValida;
            string mensaje = respuesta.mensaje!;
            DeviceResponseDto resultado = respuesta.resultado!;
            return resultado;
        }
    }
}
