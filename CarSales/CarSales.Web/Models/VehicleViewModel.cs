using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarSales.Web.Models
{
    public class VehicleViewModel
    {
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        public List<string> VehicleOtherPropertyIds { get; set; }
        public List<string> VehicleOtherPropertyNames { get; set; }

        public string VehicleOtherPropertyValues { get; set; }
        public string VehicleOtherPropertyValuesIds { get; set; }

        public string Heading { get; set; }

        public string Action => VehicleId != 0 ? "Edit" : "Add";
    }

    public class VehicleTypeProperty
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }
        public ListVehicleTypePropertyResponsePayload Payload { get; set; }

    }

    public class ListVehicleTypePropertyResponsePayload
    {
        public IEnumerable<VehicleTypePropertyListModel> VehicleTypePropertyListResult { get; set; }

    }

    public class VehicleTypePropertyListModel
    {
        public int VehicleTypePropertyId { get; set; }
        public int VehicleTypeId { get; set; }
        public int VehiclePropertyId { get; set; }
        public string VehiclePropertyName { get; set; }
    }

    public class VehicleRequest
    {
        public int VehicleTypeId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public List<string> VehicleOtherProperties { get; set; }
    }

    public class VehicleResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public VehicleResponsePayload Payload { get; set; }
    }

    public class VehicleResponsePayload
    {
        public int VehicleId { get; set; }
        public string MessageDetail { get; set; }
    }

}
