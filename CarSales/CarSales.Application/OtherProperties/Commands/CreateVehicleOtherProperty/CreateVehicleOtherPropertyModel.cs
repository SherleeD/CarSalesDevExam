using System;
using System.ComponentModel.DataAnnotations;

namespace CarSales.Application.OtherProperties.Commands.CreateVehicleOtherProperty
{
    public class CreateVehicleOtherPropertyModel
    {
        public int VehicleOtherPropertyId { get; set; }
        public int VehicleId { get; set; }
        public int VehicleTypePropertyId { get; set; }
        [MaxLength(200)]
        public string PropertyValue { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
