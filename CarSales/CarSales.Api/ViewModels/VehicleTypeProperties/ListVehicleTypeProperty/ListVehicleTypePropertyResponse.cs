
namespace CarSales.Api.ViewModels.VehicleTypeProperties.ListVehicleTypeProperty
{
    public class ListVehicleTypePropertyResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }
        public ListVehicleTypePropertyResponsePayload Payload { get; set; }
    }
}
