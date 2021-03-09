using System.Threading.Tasks;

using CarSales.Application.Vehicles.Commands.CreateVehicle;
using CarSales.Application.OtherProperties.Commands.CreateVehicleOtherProperty;

namespace CarSales.Api.Interfaces
{
    public interface IVehicleService
    {
        Task<int> AddVehicle(CreateVehicleModel vehicleModel);

        Task<int> AddVehicleOtherProperty(CreateVehicleOtherPropertyModel otherPropertyModel);


    }
}
