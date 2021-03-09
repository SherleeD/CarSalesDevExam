using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

using MediatR;
using CarSales.Api.Commands.Vehicles.AddVehicle;
using CarSales.Api.ViewModels.Vehicle;
using CarSales.Domain.Shared;

namespace CarSales.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IMediator _mediator;

        public VehicleController(ILogger<VehicleController> logger,
                                 IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }           

        // POST: api/vehicle
        [HttpPost]            
        public async Task<IActionResult> PostVehicle([FromBody] VehicleRequest vehicle)
        {
            try
            {
                _logger.LogInformation("Received create vehicle request.");


                //validate parameters
                if (vehicle.VehicleTypeId == 0)
                {
                    _logger.LogInformation("No vehicle type id found.");
                    return new JsonResult(new VehicleResponse()
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                        Message = Convert.ToString(HttpStatusCode.BadRequest),
                        Payload = new VehicleResponsePayload()
                        {
                            MessageDetail = ManageVehicleResponseStatus.NoVehicleTypeId 
                        }
                    });
                }

                if (String.IsNullOrEmpty(vehicle.Make))
                {
                    _logger.LogInformation("No make found.");
                    return new JsonResult(new VehicleResponse()
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                        Message = Convert.ToString(HttpStatusCode.BadRequest),
                        Payload = new VehicleResponsePayload()
                        {
                            MessageDetail = ManageVehicleResponseStatus.NoMakeFound
                        }
                    });
                }

                if (String.IsNullOrEmpty(vehicle.Model))
                {
                    _logger.LogInformation("No model found.");
                    return new JsonResult(new VehicleResponse()
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                        Message = Convert.ToString(HttpStatusCode.BadRequest),
                        Payload = new VehicleResponsePayload()
                        {
                            MessageDetail = ManageVehicleResponseStatus.NoModelFound
                        }
                    });
                }

                //call command handler 
                var command = new VehicleAddCommand(vehicle.VehicleTypeId, vehicle.Make, vehicle.Model, vehicle.VehicleOtherProperties);
                var commandResult = await _mediator.Send(command);

                return new JsonResult(new VehicleResponse()
                {
                    StatusCode = commandResult.StatusCode,
                    Message = commandResult.Message,
                    Payload = new VehicleResponsePayload()
                    {
                        MessageDetail = commandResult.MessageDetails,
                        VehicleId = commandResult.VehicleId                        
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("Vehicle create request failed. Exception error message: {exceptionMessage}", ex.ToString());

                return new JsonResult(new VehicleResponse()
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    Message = Convert.ToString(HttpStatusCode.BadRequest),
                    Payload = new VehicleResponsePayload()
                    {
                        MessageDetail = "Create vehicle request failed. Exception Error: " + ex.ToString()
                    }
                });
            }
        }

    
    }
}
