using Microsoft.Extensions.Logging;
using Moq;

using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

using CarSales.Api.Commands.Vehicles.AddVehicle;
using CarSales.Api.Interfaces;   

namespace CarSales.UnitTest.Api
{
    public class VehicleAddCommandHandlerTest
    {
        private readonly IVehicleService _vehicleService;
        private readonly Mock<ILogger<VehicleAddCommandHandler>> _loggerMock;

        public VehicleAddCommandHandlerTest()
        {
            _vehicleService = new VehicleServiceFake();
            _loggerMock = new Mock<ILogger<VehicleAddCommandHandler>>();
        }

        [Fact]
        public async Task CreateVehicle_ReturnOkResponse()
        {
            // Arrange
            int vehicleTypeId = 1;
            string make = "Toyota";
            string model = "Corolla Altis";
            string[] vehicleOtherProperties = { "1|16 valve dohc, fi vvti", "2|4 doors", "3|4 wheels" };

            var fakeCommand = new VehicleAddCommand(vehicleTypeId, make, model, vehicleOtherProperties);

            // Act
            var handler = new VehicleAddCommandHandler(_loggerMock.Object, _vehicleService);
            var cancellationToken = new System.Threading.CancellationToken();
            var result = await handler.Handle(fakeCommand, cancellationToken);


            // Assert
            Assert.Equal(Convert.ToInt32(HttpStatusCode.OK), result.StatusCode);
            Assert.Equal(Convert.ToString(HttpStatusCode.OK), result.Message);
            Assert.NotNull(result.MessageDetails);
            Assert.Equal(result.VehicleId, result.VehicleId);
        }
    }
}
