
namespace CarSales.Api.ViewModels.VehicleTypeProperties
{
    public class VehicleTypePropertyResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public VehicleTypePropertyResponsePayload Payload { get; set; }
    }
}
