using CarSales.Application.VehicleTypeProperties.Queries.GetVehicleTypePropertyList;
using System.Collections.Generic;

namespace CarSales.Api.Queries.VehicleTypeProperties.ListVehicleTypeProperty
{
    public class ListVehicleTypePropertyResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string MessageDetails { get; set; }

        public IEnumerable<VehicleTypePropertyListModel> VehicleTypePropertyListResults { get; set; }

    }
}
