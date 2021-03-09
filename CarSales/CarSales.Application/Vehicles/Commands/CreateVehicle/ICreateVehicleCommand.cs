using System.Threading.Tasks;

namespace CarSales.Application.Vehicles.Commands.CreateVehicle
{
    public interface ICreateVehicleCommand
    {
        Task Execute(CreateVehicleModel model);
    }
}
