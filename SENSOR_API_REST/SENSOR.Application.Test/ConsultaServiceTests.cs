// Archivo: VENTA.Tests/Services/ConsultaServiceTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SENSOR.Application.Interface;
using SENSOR.Dto;
using System;
using System.Threading.Tasks;
using VENTA.Dto;

namespace VENTA.Tests.Services
{
    [TestClass]
    public class ConsultaServiceTests
    {
        private Mock<IConsultaService> _consultaServiceMock;

        [TestInitialize]
        public void Setup()
        {
            _consultaServiceMock = new Mock<IConsultaService>();
        }

        [TestMethod]
        public async Task GetDatosSensor_ReturnsExpectedResult()
        {
            // Arrange
            var fechaDesde = new DateTime(2023, 1, 1);
            var fechaHasta = new DateTime(2023, 1, 31);
            var modo = "test";
            var expectedResponse = new RespuestaGenerica<DeviceResponseDto>
            {
                // Inicializar con datos de prueba
            };

            _consultaServiceMock
                .Setup(service => service.GetDatosSensor(fechaDesde, fechaHasta, modo))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _consultaServiceMock.Object.GetDatosSensor(fechaDesde, fechaHasta, modo);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResponse, result);
        }

        [TestMethod]
        public async Task GetDatosSensor_ThrowsException()
        {
            // Arrange
            var fechaDesde = new DateTime(2023, 1, 1);
            var fechaHasta = new DateTime(2023, 1, 31);
            var modo = "test";

            _consultaServiceMock
                .Setup(service => service.GetDatosSensor(fechaDesde, fechaHasta, modo))
                .ThrowsAsync(new Exception("Test exception"));

            // Act & Assert
            await Assert.ThrowsExceptionAsync<Exception>(() => _consultaServiceMock.Object.GetDatosSensor(fechaDesde, fechaHasta, modo));
        }
    }
}
