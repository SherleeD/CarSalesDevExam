using System.Threading.Tasks;
using System;

using CarSales.Domain;
using CarSales.Persistence;


namespace CarSales.Application.OtherProperties.Commands.CreateVehicleOtherProperty
{
    public class CreateVehicleOtherPropertyCommand : ICreateVehicleOtherPropertyCommand
    {
        public readonly CarSalesContext _context;

        public CreateVehicleOtherPropertyCommand(CarSalesContext context)
        {
            _context = context;
        }

        public async Task Execute(CreateVehicleOtherPropertyModel model)
        {
            var entity = new VehicleOtherProperty 
            {
                VehicleId = model.VehicleId,
                VehicleTypePropertyId = model.VehicleTypePropertyId,
                PropertyValue = model.PropertyValue,
                DateCreated = DateTime.UtcNow,
            };

            _context.VehicleOtherProperties.Add(entity);

            await _context.SaveChangesAsync();
            model.VehicleOtherPropertyId = entity.VehicleOtherPropertyId;

        }
    }
}
