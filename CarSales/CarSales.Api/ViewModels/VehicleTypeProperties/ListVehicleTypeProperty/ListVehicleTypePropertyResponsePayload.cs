using System.Collections.Generic;
using CarSales.Application.VehicleTypeProperties.Queries.GetVehicleTypePropertyList;

namespace CarSales.Api.ViewModels.VehicleTypeProperties.ListVehicleTypeProperty
{
    public class ListVehicleTypePropertyResponsePayload
    {
        public IEnumerable<VehicleTypePropertyListModel> VehicleTypePropertyListResult { get; set; }

    }
}
