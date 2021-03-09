using MediatR;
using System;

namespace CarSales.Api.Commands.Vehicles.AddVehicle
{
    public class VehicleAddCommand : IRequest<VehiclesResults>
    {
        public int VehicleTypeId { get; set; }
        
        public string Make { get; set; }
        
        public string Model { get; set; }
        public string[] VehicleOtherProperties { get; set; }

        protected VehicleAddCommand() { }

        public VehicleAddCommand(int vehicleTypeId, string make, string model, string[] vehicleOtherProperties) : this()
        {
            VehicleTypeId = vehicleTypeId;
            Make = make;
            Model = model;
            VehicleOtherProperties = vehicleOtherProperties;
        }
    }
}
