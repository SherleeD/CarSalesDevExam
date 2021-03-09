using Moq;
using Xunit;
using MediatR;

using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

using CarSales.Api.Controllers;
using CarSales.Api.ViewModels.VehicleTypeProperties.ListVehicleTypeProperty;
using CarSales.Api.Queries.VehicleTypeProperties.ListVehicleTypeProperty;

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using CarSales.Application.VehicleTypeProperties.Queries.GetVehicleTypePropertyList;

namespace CarSales.UnitTest.Api.VehicleTypeProperty
{
    public class VehicleTypePropertiesControllerTest
    {
        VehicleTypePropertiesController _vehicleTypePropertiesController;
        private readonly Mock<ILogger<VehicleTypePropertiesController>> _loggerMock;
        private readonly Mock<IMediator> _mediatorMock;

        public VehicleTypePropertiesControllerTest()
        {
            _loggerMock = new Mock<ILogger<VehicleTypePropertiesController>>();
            _mediatorMock = new Mock<IMediator>();
            _vehicleTypePropertiesController = new VehicleTypePropertiesController(_loggerMock.Object, _mediatorMock.Object);
        }

        [Fact]
        public async void NoVehicleTypeId_ReturnsBadRequest()
        {
            // Arrange
            int vehicleTypeId = 0;
            
            var _vehicleTypePropertiesController = new VehicleTypePropertiesController(_loggerMock.Object, _mediatorMock.Object);

            // Act            
            var result = await _vehicleTypePropertiesController.GetVehicleTypeProperties(vehicleTypeId) as JsonResult;
            var response = result.Value as ListVehicleTypePropertyResponse;

            // Assert            
            Assert.Equal(Convert.ToInt32(HttpStatusCode.BadRequest), response.StatusCode);
            Assert.Equal(Convert.ToString(HttpStatusCode.BadRequest), response.Message);
            Assert.Equal("No vehicle type id found.", response.MessageDetail);

        }

        [Fact]
        public async void ValidInfo_ReturnsOkRequest()
        {
            // Arrange
            int vehicleTypeId = 1;

            var _vehicleTypePropertiesController = new VehicleTypePropertiesController(_loggerMock.Object, _mediatorMock.Object);

            List<VehicleTypePropertyListModel> propertyList = new List<VehicleTypePropertyListModel>();
            VehicleTypePropertyListModel testProperty = new VehicleTypePropertyListModel();

            testProperty.VehicleTypePropertyId = 1;
            testProperty.VehicleTypeId = 1;
            testProperty.VehiclePropertyId = 1;
            testProperty.VehiclePropertyName = "Engine";

            propertyList.Add(testProperty);


            var commandResult = new ListVehicleTypePropertyResult
            {
                StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                Message = Convert.ToString(HttpStatusCode.OK),
                MessageDetails = "Vehicle type property list retrieve successful",
                VehicleTypePropertyListResults = propertyList
            };

            _mediatorMock.Setup(x => x.Send(It.IsAny<ListVehicleTypePropertyQuery>(), default(CancellationToken)))
               .Returns(Task.FromResult(commandResult));

            // Act            
            var result = await _vehicleTypePropertiesController.GetVehicleTypeProperties(vehicleTypeId) as JsonResult;
            var response = result.Value as ListVehicleTypePropertyResponse;

            // Assert            
            Assert.Equal(Convert.ToInt32(HttpStatusCode.OK), response.StatusCode);
            Assert.Equal(Convert.ToString(HttpStatusCode.OK), response.Message);
            Assert.Equal("Vehicle type property list retrieve successful", response.MessageDetail);
            Assert.NotNull(response.Payload.VehicleTypePropertyListResult);            
        }

    }
}
