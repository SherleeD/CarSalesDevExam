using Moq;
using Xunit;
using MediatR;

using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

using CarSales.Api.Controllers;
using CarSales.Api.Commands;
using CarSales.Api.Commands.Vehicles;
using CarSales.Api.Commands.Vehicles.AddVehicle;
using CarSales.Api.ViewModels;
using CarSales.Api.ViewModels.Vehicle;
using CarSales.Domain.Shared;

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;


namespace CarSales.UnitTest.Api
{
    public class VehicleControllerTest
    {
        VehicleController _vehicleController;
        private readonly Mock<ILogger<VehicleController>> _loggerMock;
        private readonly Mock<IMediator> _mediatorMock;

        public VehicleControllerTest()
        {
            _loggerMock = new Mock<ILogger<VehicleController>>();
            _mediatorMock = new Mock<IMediator>();
            _vehicleController = new VehicleController(_loggerMock.Object, _mediatorMock.Object);
        }

        [Fact]
        public async void NoVehicleTypeId_ReturnsNoBadRequest()
        {
            // Arrange
            int vehicleTypeId = 0;
            string make = "Test Make";
            string model = "Test Model";
            string[] vehicleOtherProperties = { };

            var request = new VehicleRequest(vehicleTypeId, make, model, vehicleOtherProperties);            
            var _vehicleController = new VehicleController(_loggerMock.Object, _mediatorMock.Object);

            // Act            
            var result = await _vehicleController.PostVehicle(request) as JsonResult;
            var response = result.Value as VehicleResponse;

            // Assert            
            Assert.Equal(Convert.ToInt32(HttpStatusCode.BadRequest), response.StatusCode);
            Assert.Equal(Convert.ToString(HttpStatusCode.BadRequest), response.Message);
            Assert.Equal("No vehicle type id found.", response.Payload.MessageDetail);                       
        }

        [Fact]
        public async void NoMakeFound_ReturnsNoBadRequest()
        {
            // Arrange
            int vehicleTypeId = 1;
            string make = "";
            string model = "Test Model";
            string[] vehicleOtherProperties = { };

            var request = new VehicleRequest(vehicleTypeId, make, model, vehicleOtherProperties);
            var _vehicleController = new VehicleController(_loggerMock.Object, _mediatorMock.Object);

            // Act            
            var result = await _vehicleController.PostVehicle(request) as JsonResult;
            var response = result.Value as VehicleResponse;

            // Assert
            Assert.Equal(Convert.ToInt32(HttpStatusCode.BadRequest), response.StatusCode);
            Assert.Equal(Convert.ToString(HttpStatusCode.BadRequest), response.Message);
            Assert.Equal("No make found.", response.Payload.MessageDetail);
        }

        [Fact]
        public async void NoModelFound_ReturnsNoBadRequest()
        {
            // Arrange
            int vehicleTypeId = 1;
            string make = "Test Make";
            string model = "";
            string[] vehicleOtherProperties = { };

            var request = new VehicleRequest(vehicleTypeId, make, model, vehicleOtherProperties);
            var _vehicleController = new VehicleController(_loggerMock.Object, _mediatorMock.Object);

            // Act            
            var result = await _vehicleController.PostVehicle(request) as JsonResult;
            var response = result.Value as VehicleResponse;

            // Assert
            Assert.Equal(Convert.ToInt32(HttpStatusCode.BadRequest), response.StatusCode);
            Assert.Equal(Convert.ToString(HttpStatusCode.BadRequest), response.Message);
            Assert.Equal("No model found.", response.Payload.MessageDetail);
        }

        [Fact]
        public async void ValidInfo_ReturnsOkRequest()
        {
            // Arrange
            int vehicleTypeId = 1;
            string make = "Toyota";
            string model = "Corolla Altis";
            string[] vehicleOtherProperties = { "1|16 valve dohc, fi vvti", "2|4 doors", "3|4 wheels" };

            var request = new VehicleRequest(vehicleTypeId, make, model, vehicleOtherProperties);

            var commandResult = new VehiclesResults
            {                
                StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                Message = Convert.ToString(HttpStatusCode.OK),
                MessageDetails = "Vehicle successfully created.",
                VehicleId =  1                
            };            

            _mediatorMock.Setup(x => x.Send(It.IsAny<VehicleAddCommand>(), default(CancellationToken)))
                .Returns(Task.FromResult(commandResult));

            // Act            
            var result = await _vehicleController.PostVehicle(request) as JsonResult;
            var response = result.Value as VehicleResponse;

            // Assert
            Assert.Equal(Convert.ToInt32(HttpStatusCode.OK), response.StatusCode);
            Assert.Equal(Convert.ToString(HttpStatusCode.OK), response.Message);
            Assert.Equal("Vehicle successfully created.", response.Payload.MessageDetail);
        }


    }
}
