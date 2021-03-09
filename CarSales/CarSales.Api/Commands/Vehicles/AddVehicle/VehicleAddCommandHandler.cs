using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

using CarSales.Api.Interfaces;
using CarSales.Domain.Shared;
using CarSales.Application.Vehicles.Commands.CreateVehicle;
using CarSales.Application.OtherProperties.Commands.CreateVehicleOtherProperty;

namespace CarSales.Api.Commands.Vehicles.AddVehicle
{
    public class VehicleAddCommandHandler : IRequestHandler<VehicleAddCommand, VehiclesResults>
    {
        private readonly ILogger<VehicleAddCommandHandler> _logger;
        private readonly IVehicleService _vehicleService;        

        public VehicleAddCommandHandler(ILogger<VehicleAddCommandHandler> logger,
                                        IVehicleService  vehicleService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _vehicleService = vehicleService ?? throw new ArgumentNullException(nameof(vehicleService));
        }

        public async Task<VehiclesResults> Handle(VehicleAddCommand command, CancellationToken cancellationToken)
        {
            try 
            {
                _logger.LogInformation("Creating contact started.");

                CreateVehicleModel vehicle = new CreateVehicleModel();
                CreateVehicleOtherPropertyModel otherVehicleProperty = new CreateVehicleOtherPropertyModel();

                vehicle.VehicleTypeId = command.VehicleTypeId;
                vehicle.Make = command.Make;
                vehicle.Model = command.Model;
                vehicle.VehicleOtherProperties = command.VehicleOtherProperties;

                //call saving of vehicle record
                await _vehicleService.AddVehicle(vehicle);                             
                
                //check if vehicle has other property
                if (command.VehicleOtherProperties.Length > 0)
                {
                    foreach (var rec in command.VehicleOtherProperties)
                    {
                        string[] propertListValues = rec.Split("|");

                        otherVehicleProperty.VehicleTypePropertyId = Convert.ToInt32(propertListValues[0]);
                        otherVehicleProperty.PropertyValue = propertListValues[1].ToString();
                        otherVehicleProperty.VehicleId = vehicle.VehicleId;


                        //call saving of other vehicle property
                        await _vehicleService.AddVehicleOtherProperty(otherVehicleProperty);
                    }
                }                

                return new VehiclesResults
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                    Message = Convert.ToString(HttpStatusCode.OK),
                    MessageDetails = ManageVehicleResponseStatus.Created,
                    VehicleId = vehicle.VehicleId                    
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error creating vehicle : {ExceptionMessage}", ex.ToString());

                return new VehiclesResults
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError),
                    Message = Convert.ToString(HttpStatusCode.InternalServerError),
                    MessageDetails = ManageVehicleResponseStatus.CreateFailed
                };
            }
        }
    }
}
