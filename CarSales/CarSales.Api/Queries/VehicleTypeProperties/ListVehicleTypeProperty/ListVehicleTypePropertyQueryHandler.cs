using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;

using CarSales.Application.VehicleTypeProperties.Queries.GetVehicleTypePropertyList;
using CarSales.Api.Interfaces;
using CarSales.Domain.Shared;

namespace CarSales.Api.Queries.VehicleTypeProperties.ListVehicleTypeProperty
{
    public class ListVehicleTypePropertyQueryHandler : IRequestHandler<ListVehicleTypePropertyQuery, ListVehicleTypePropertyResult>
    {
        private readonly ILogger<ListVehicleTypePropertyQueryHandler> _logger;
        private readonly IVehicleTypePropertyService _vehicleTypePropertyService;

        public ListVehicleTypePropertyQueryHandler(
             ILogger<ListVehicleTypePropertyQueryHandler> logger,
             IVehicleTypePropertyService vehicleTypePropertyService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _vehicleTypePropertyService = vehicleTypePropertyService ?? throw new ArgumentNullException(nameof(vehicleTypePropertyService));
        }

        public async Task<ListVehicleTypePropertyResult> Handle(ListVehicleTypePropertyQuery query, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<VehicleTypePropertyListModel> vehicleTypePropertyListResult;                

                vehicleTypePropertyListResult = await _vehicleTypePropertyService.ListVehicleTypeProperties(query.VehicleTypeId);

                return new ListVehicleTypePropertyResult
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                    Message = Convert.ToString(HttpStatusCode.OK),
                    MessageDetails = ManageVehicleTypePropertiesResponseStatus.VehicleTypePropertyListRetrieveSuccessful,
                    VehicleTypePropertyListResults = vehicleTypePropertyListResult                    
                };


            }
            catch (Exception ex)
            {
                _logger.LogError("Error retrieving vehicle type properties : {ExceptionMessage}", ex.ToString());

                return new ListVehicleTypePropertyResult
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError),
                    Message = Convert.ToString(HttpStatusCode.InternalServerError),
                    MessageDetails = ManageVehicleTypePropertiesResponseStatus.VehicleTypePropertyListRetrieveFailed
                };
            }
        }
    }
}
