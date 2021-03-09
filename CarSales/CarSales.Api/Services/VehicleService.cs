using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using CarSales.Api.Interfaces;
using CarSales.Application.Vehicles.Commands.CreateVehicle;
using CarSales.Application.OtherProperties.Commands.CreateVehicleOtherProperty;

namespace CarSales.Api.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly ILogger<VehicleService> _logger;
        private readonly ICreateVehicleCommand _createVehicleCommand;
        private readonly ICreateVehicleOtherPropertyCommand _createVehicleOtherPropertyCommand;


        public VehicleService(ILogger<VehicleService> logger,
            ICreateVehicleCommand createVehicleCommand,
            ICreateVehicleOtherPropertyCommand createVehicleOtherPropertyCommand)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _createVehicleCommand = createVehicleCommand;
            _createVehicleOtherPropertyCommand = createVehicleOtherPropertyCommand;

        }

        public async Task<int> AddVehicle(CreateVehicleModel vehicleModel)
        {
            await _createVehicleCommand.Execute(vehicleModel);

            return vehicleModel.VehicleId;
        }

        public async Task<int> AddVehicleOtherProperty(CreateVehicleOtherPropertyModel otherPropertyModel)
        {
            await _createVehicleOtherPropertyCommand.Execute(otherPropertyModel);

            return otherPropertyModel.VehicleOtherPropertyId;
        }
    }
}
