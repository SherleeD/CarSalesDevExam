using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSales.Domain
{
    public class VehicleTypeProperty
    {
        public VehicleTypeProperty()
        {
        }

        [Key]
        public int VehicleTypePropertyId { get; set; }
        public int VehicleTypeId { get; set; }
        public int VehiclePropertyId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        [ForeignKey("VehicleTypeId")]
        public VehicleType VehicleType { get; set; }

        [ForeignKey("VehiclePropertyId")]
        public VehicleProperty VehicleProperty { get; set; }


    }
}
