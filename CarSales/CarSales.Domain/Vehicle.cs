using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSales.Domain
{
    public class Vehicle
    {
        public Vehicle()
        {
        }

        [Key]
        public int VehicleId { get; set; }        
        public int VehicleTypeId { get; set; }
        [MaxLength(200)]
        public string Make { get; set; }
        [MaxLength(200)]
        public string Model { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        
        public VehicleType VehicleType { get; set; }

    }
}
