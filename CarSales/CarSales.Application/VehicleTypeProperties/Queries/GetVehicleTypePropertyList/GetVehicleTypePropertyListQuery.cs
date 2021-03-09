using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using CarSales.Persistence;


namespace CarSales.Application.VehicleTypeProperties.Queries.GetVehicleTypePropertyList
{
    public class GetVehicleTypePropertyListQuery : IGetVehicleTypePropertyListQuery
    {
        public readonly CarSalesContext _context;

        public GetVehicleTypePropertyListQuery(CarSalesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleTypePropertyListModel>> Execute(int vehicleTypeId)
        {
            var queryResult = await _context.VehicleTypeProperties
                .Where(x => x.VehicleTypeId == vehicleTypeId)
                .Include(t => t.VehicleProperty)
                .ToListAsync();

            var list = queryResult.Select(r => new VehicleTypePropertyListModel()
            {
                VehicleTypePropertyId = r.VehicleTypePropertyId,
                VehicleTypeId = r.VehicleTypeId,
                VehiclePropertyId = r.VehiclePropertyId,
                VehiclePropertyName = r.VehicleProperty.VehiclePropertyName

            });

            return list;
        }
    }
}
