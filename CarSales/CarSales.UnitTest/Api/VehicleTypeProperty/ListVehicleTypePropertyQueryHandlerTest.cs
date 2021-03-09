using Microsoft.Extensions.Logging;
using Moq;

using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

using CarSales.Api.Queries.VehicleTypeProperties.ListVehicleTypeProperty;
using CarSales.Api.Interfaces;

namespace CarSales.UnitTest.Api.VehicleTypeProperty
{
    public class ListVehicleTypePropertyQueryHandlerTest
    {
        private readonly IVehicleTypePropertyService _vehicleTypePropertyService;
        private readonly Mock<ILogger<ListVehicleTypePropertyQueryHandler>> _loggerMock;

        public ListVehicleTypePropertyQueryHandlerTest()
        {
            _vehicleTypePropertyService = new VehicleTypePropertyServiceFake();
            _loggerMock = new Mock<ILogger<ListVehicleTypePropertyQueryHandler>>();
        }

        [Fact]
        public async Task ListVehicleTypeProperty_ReturnOkResponse()
        {
            // Arrange
            int vehicleTypeId = 1;

            var fakeQuery = new ListVehicleTypePropertyQuery(vehicleTypeId);

            // Act
            var handler = new ListVehicleTypePropertyQueryHandler(_loggerMock.Object, _vehicleTypePropertyService);
            var cancellationToken = new System.Threading.CancellationToken();
            var result = await handler.Handle(fakeQuery, cancellationToken);

            // Assert
            Assert.Equal(Convert.ToInt32(HttpStatusCode.OK), result.StatusCode);
            Assert.Equal(Convert.ToString(HttpStatusCode.OK), result.Message);
            Assert.NotNull(result.MessageDetails);
            Assert.NotNull(result.VehicleTypePropertyListResults);
        }
    }
}
