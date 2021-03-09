using MediatR;

namespace CarSales.Api.Queries.VehicleTypeProperties.ListVehicleTypeProperty
{
    public class ListVehicleTypePropertyQuery : IRequest<ListVehicleTypePropertyResult>
    {
        public int VehicleTypeId { get; set; }

        protected ListVehicleTypePropertyQuery()
        {
        }

        public ListVehicleTypePropertyQuery(int vehicleTypeId) : this()
        {
            VehicleTypeId = vehicleTypeId;
        }

    }
}
