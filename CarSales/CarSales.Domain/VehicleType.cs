using System;
using System.ComponentModel.DataAnnotations;

namespace CarSales.Domain
{
    public class VehicleType
    {
        public VehicleType()
        {
        }

        [Key]
        public int VehicleTypeId { get; set; }
        [MaxLength(50)]
        public string VehicleTypeName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

    }
}
