using CarSales.Api.Services;
using CarSales.Api.Interfaces;
using CarSales.Application.Vehicles.Commands.CreateVehicle;


using Microsoft.Extensions.Logging;

using Moq;

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CarSales.Application.OtherProperties.Commands.CreateVehicleOtherProperty;

namespace CarSales.UnitTest.Api
{
    public class VehicleServiceFake : IVehicleService
    {
        private readonly Mock<ILogger<VehicleService>> _loggerMock;

        public VehicleServiceFake()
        {
            _loggerMock = new Mock<ILogger<VehicleService>>();
        }

        public async Task<int> AddVehicle(CreateVehicleModel vehicleModel)
        {
            vehicleModel.VehicleId = 1;

            return vehicleModel.VehicleId;
        }

        public async Task<int> AddVehicleOtherProperty(CreateVehicleOtherPropertyModel otherPropertyModel)
        {
            otherPropertyModel.VehicleOtherPropertyId = 1;

            return otherPropertyModel.VehicleOtherPropertyId;
        }
    }
}
