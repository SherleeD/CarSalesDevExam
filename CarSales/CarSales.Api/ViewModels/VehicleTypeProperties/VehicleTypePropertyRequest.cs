
namespace CarSales.Api.ViewModels.VehicleTypeProperties
{
    public class VehicleTypePropertyRequest
    {
        public int VehicleTypeId { get; set; }

        protected VehicleTypePropertyRequest()
        {
        }

        public VehicleTypePropertyRequest(int vehicleTypeId) : this()
        {
            VehicleTypeId = vehicleTypeId;
        }
    }
}
