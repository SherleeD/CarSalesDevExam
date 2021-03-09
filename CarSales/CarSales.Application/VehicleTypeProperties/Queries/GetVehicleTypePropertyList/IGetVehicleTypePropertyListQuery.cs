using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSales.Application.VehicleTypeProperties.Queries.GetVehicleTypePropertyList
{
    public interface IGetVehicleTypePropertyListQuery
    {
        Task<IEnumerable<VehicleTypePropertyListModel>> Execute(int VehicleTypeId);
    }
}
