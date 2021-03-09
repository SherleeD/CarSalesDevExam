using System.Threading.Tasks;
using System.Collections.Generic;

using CarSales.Application.VehicleTypeProperties.Queries.GetVehicleTypePropertyList;


namespace CarSales.Api.Interfaces
{
    public interface IVehicleTypePropertyService
    {
        Task<IEnumerable<VehicleTypePropertyListModel>> ListVehicleTypeProperties(int vehicleTypeId);
    }
}
