using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using CarSales.Api.Interfaces;
using CarSales.Application.VehicleTypeProperties.Queries.GetVehicleTypePropertyList;


namespace CarSales.Api.Services
{
    public class VehicleTypePropertyService : IVehicleTypePropertyService
    {
        private readonly ILogger<VehicleTypePropertyService> _logger;
        private readonly IGetVehicleTypePropertyListQuery _getVehicleTypePropertyListQuery;

        public VehicleTypePropertyService(ILogger<VehicleTypePropertyService> logger,
            IGetVehicleTypePropertyListQuery getVehicleTypePropertyListQuery)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _getVehicleTypePropertyListQuery = getVehicleTypePropertyListQuery;
        }

        public async Task<IEnumerable<VehicleTypePropertyListModel>> ListVehicleTypeProperties(int vehicleTypeId)
        {
            //call applicaton command to list vehicle type properties
            return await _getVehicleTypePropertyListQuery.Execute(vehicleTypeId);
        }
    }
}
