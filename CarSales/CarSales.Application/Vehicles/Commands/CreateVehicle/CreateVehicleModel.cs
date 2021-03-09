using System;
using System.ComponentModel.DataAnnotations;

namespace CarSales.Application.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleModel
    {
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        [MaxLength(200)]
        public string Make { get; set; }
        [MaxLength(200)]
        public string Model { get; set; }
        public string[] VehicleOtherProperties { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        
    }
}
