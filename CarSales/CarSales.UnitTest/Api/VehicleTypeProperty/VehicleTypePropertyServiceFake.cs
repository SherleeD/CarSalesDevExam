using CarSales.Api.Services;
using CarSales.Api.Interfaces;
using CarSales.Application.VehicleTypeProperties.Queries.GetVehicleTypePropertyList;

using Microsoft.Extensions.Logging;

using Moq;

using System.Threading.Tasks;
using System.Collections.Generic;

namespace CarSales.UnitTest.Api.VehicleTypeProperty
{
    public class VehicleTypePropertyServiceFake : IVehicleTypePropertyService
    {
        private readonly Mock<ILogger<VehicleTypePropertyService>> _loggerMock;

        public VehicleTypePropertyServiceFake()
        {
            _loggerMock = new Mock<ILogger<VehicleTypePropertyService>>();
        }

        public async Task<IEnumerable<VehicleTypePropertyListModel>> ListVehicleTypeProperties(int vehicleTypeId)
        {
            vehicleTypeId = 1;

            List<VehicleTypePropertyListModel> propertyList = new List<VehicleTypePropertyListModel>();
            VehicleTypePropertyListModel testProperty = new VehicleTypePropertyListModel();

            testProperty.VehicleTypePropertyId = 1;
            testProperty.VehicleTypeId = 1;
            testProperty.VehiclePropertyId = 1;
            testProperty.VehiclePropertyName = "Engine";

            propertyList.Add(testProperty);

            return propertyList;
        }
    }
}
