using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENSOR.Application.Interface;

namespace SENSOR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _eventoService;

        public ConsultaController(IConsultaService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet("{fechaDesde}/{fechaHasta}/{modo}")]
        public async Task<JsonResult> GetDatosSensor(string fechaDesde, string fechaHasta, string modo)
        {
            DateTime.TryParse(fechaDesde, out var fechaUno);
            DateTime.TryParse(fechaHasta, out var fechaDos);
            return new JsonResult(await _eventoService.GetDatosSensor(fechaUno, fechaDos, modo));
        }
    }
}
