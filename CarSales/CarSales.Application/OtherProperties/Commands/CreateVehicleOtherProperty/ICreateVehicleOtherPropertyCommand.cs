using System.Threading.Tasks;

namespace CarSales.Application.OtherProperties.Commands.CreateVehicleOtherProperty
{
    public interface ICreateVehicleOtherPropertyCommand
    {
        Task Execute(CreateVehicleOtherPropertyModel model);
    }
}
