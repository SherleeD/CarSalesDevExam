using System;
using System.ComponentModel.DataAnnotations;

namespace CarSales.Domain
{
    public class VehicleProperty
    {
        public VehicleProperty()
        {
        }

        [Key]
        public int VehiclePropertyId { get; set; }
        [MaxLength(200)]
        public string VehiclePropertyName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
