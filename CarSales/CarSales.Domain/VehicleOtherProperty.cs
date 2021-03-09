using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSales.Domain
{
    public class VehicleOtherProperty
    {
        public VehicleOtherProperty()
        {
        }

        [Key]
        public int VehicleOtherPropertyId { get; set; }
        public int VehicleId { get; set; }
        public int VehicleTypePropertyId { get; set; }
        [MaxLength(200)]
        public string PropertyValue { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }
                
    }
}
