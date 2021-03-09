
namespace CarSales.Api.ViewModels.Vehicle
{
    public class VehicleRequest
    {    
        public int VehicleTypeId { get; set; }        
        public string Make { get; set; }        
        public string Model { get; set; }
        public string[] VehicleOtherProperties { get; set; }

        protected VehicleRequest()
        {
        }

        public VehicleRequest(int vehicleTypeId, string make, string model, string[] vehicleOtherProperties) : this()
        {
            VehicleTypeId = vehicleTypeId;
            Make = make;
            Model = model;
            VehicleOtherProperties = vehicleOtherProperties;
        }
    }
}
