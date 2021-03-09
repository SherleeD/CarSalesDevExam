using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

using MediatR;
using CarSales.Api.Commands.Vehicles.AddVehicle;
using CarSales.Api.ViewModels;
using CarSales.Domain.Shared;

using CarSales.Application.VehicleTypeProperties.Queries.GetVehicleTypePropertyList;
using CarSales.Api.Queries.VehicleTypeProperties.ListVehicleTypeProperty;
using CarSales.Api.ViewModels.VehicleTypeProperties.ListVehicleTypeProperty;

namespace CarSales.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypePropertiesController : Controller
    {

        private readonly ILogger<VehicleTypePropertiesController> _logger;
        private readonly IMediator _mediator;

        public VehicleTypePropertiesController(ILogger<VehicleTypePropertiesController> logger,
                                               IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // Get VehicleTypeProperties based on VehicleTypeId
        // GET: api/VehicleTypeProperties/5
        [HttpGet("{vehicleTypeId}")]        
        public async Task<IActionResult> GetVehicleTypeProperties(int vehicleTypeId)
        {
            try
            {
                if (vehicleTypeId == 0)
                {
                    return new JsonResult(new ListVehicleTypePropertyResponse()
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                        Message = Convert.ToString(HttpStatusCode.BadRequest),
                        MessageDetail = ManageVehicleTypePropertiesResponseStatus.NoVehicleTypeId
                    });
                }

                var query = new ListVehicleTypePropertyQuery(vehicleTypeId);
                var queryResult = await _mediator.Send(query);
                
                return new JsonResult(new ListVehicleTypePropertyResponse()
                {
                    StatusCode = queryResult.StatusCode,
                    Message = queryResult.Message,
                    MessageDetail = queryResult.MessageDetails,
                    Payload = new ListVehicleTypePropertyResponsePayload()
                    {
                        VehicleTypePropertyListResult = queryResult.VehicleTypePropertyListResults
                    }
                });

            }
            catch (Exception ex)
            {

                _logger.LogError("Get vehicle type properties request failed. Exception error message: {exceptionMessage}", ex.ToString());

                return new JsonResult(new ListVehicleTypePropertyResponse()
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    Message = Convert.ToString(HttpStatusCode.BadRequest),
                    MessageDetail = "Get group detail request failed. Exception error message: " + ex.ToString()
                });
            }
        }

    }
}
