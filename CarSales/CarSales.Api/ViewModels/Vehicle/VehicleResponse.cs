
namespace CarSales.Api.ViewModels.Vehicle
{
    public class VehicleResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public VehicleResponsePayload Payload { get; set; }
    }
}
