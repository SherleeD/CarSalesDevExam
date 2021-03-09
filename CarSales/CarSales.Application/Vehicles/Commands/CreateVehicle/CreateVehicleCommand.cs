using System.Threading.Tasks;
using System;

using CarSales.Domain;
using CarSales.Persistence;

namespace CarSales.Application.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommand : ICreateVehicleCommand
    {
        public readonly CarSalesContext _context;

        public CreateVehicleCommand(CarSalesContext context)
        {
            _context = context;
        }

        public async Task Execute(CreateVehicleModel model)
        {
            var entity = new Vehicle
            {
                VehicleTypeId = model.VehicleTypeId,
                Make = model.Make,
                Model = model.Model,
                DateCreated = DateTime.UtcNow,
            };

            _context.Vehicles.Add(entity);

            await _context.SaveChangesAsync();
            model.VehicleId = entity.VehicleId;

        }
    }
}
