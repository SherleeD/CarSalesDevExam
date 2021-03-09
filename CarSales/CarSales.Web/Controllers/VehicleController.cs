using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using CarSales.Web.Models;

using Newtonsoft.Json;
using System.Text;

namespace CarSales.Web.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IConfiguration _configure;
        private readonly string apiBaseUrl;

        public object JsonSerializerOptions { get; private set; }

        public VehicleController(ILogger<VehicleController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configure = configuration;
            apiBaseUrl = _configure.GetValue<string>("WebAPIBaseUrl");
        }

        public IActionResult Index()
        {
            return View();            
        }

        [HttpGet]
        public async Task<IActionResult> AddAsync(int vehicleTypeId)
        {
            try
            {
                HttpClient client = new HttpClient();

                VehicleTypeProperty vehicleTypeProperty = new VehicleTypeProperty();
                List<string> vehicleOtherPropertIds = new List<string>();
                List<string> vehicleOtherPropertNames = new List<string>();

                client.BaseAddress = new Uri(apiBaseUrl);                

                string requestUri = "/api/VehicleTypeProperties/" + vehicleTypeId;

                //call api to get list of selected vehicle type properties
                var response = await client.GetAsync(requestUri);

                string apiResponse = await response.Content.ReadAsStringAsync();

                vehicleTypeProperty = JsonConvert.DeserializeObject<VehicleTypeProperty>(apiResponse);

                if (vehicleTypeProperty.StatusCode == 200)
                {
                    if (vehicleTypeProperty.Payload.VehicleTypePropertyListResult.Count() > 0)
                    {
                        foreach (var rec in vehicleTypeProperty.Payload.VehicleTypePropertyListResult)
                        {
                            //from the api get all the propertyid and names and store in different arrays                         
                            vehicleOtherPropertIds.Add(rec.VehicleTypePropertyId.ToString());
                            vehicleOtherPropertNames.Add(rec.VehiclePropertyName);
                        }
                    }
                }

                var viewModel = new VehicleViewModel
                {
                    Heading = "New Vehicle",
                    VehicleOtherPropertyIds = vehicleOtherPropertIds,
                    VehicleOtherPropertyNames = vehicleOtherPropertNames,
                    VehicleTypeId = 1
                };

                return View("VehicleForm", viewModel);

            }
            catch (Exception ex)
            {
                _logger.LogError("An Exception error was encountered : {ExceptionMessage}", ex.ToString());

                return View("Error");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(VehicleViewModel viewModel)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(apiBaseUrl);

                if (!ModelState.IsValid)
                {                               
                    VehicleTypeProperty vehicleTypeProperty = new VehicleTypeProperty();
                    List<string> vehicleOtherPropertIds = new List<string>();
                    List<string> vehicleOtherPropertNames = new List<string>();
                    
                    string requestUri = "/api/VehicleTypeProperties/" + viewModel.VehicleTypeId;

                    //call api to get list of selected vehicle type properties     
                    var response = await client.GetAsync(requestUri);

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    vehicleTypeProperty = JsonConvert.DeserializeObject<VehicleTypeProperty>(apiResponse);

                    if (vehicleTypeProperty.StatusCode == 200)
                    {
                        if (vehicleTypeProperty.Payload.VehicleTypePropertyListResult.Count() > 0)
                        {
                            foreach (var rec in vehicleTypeProperty.Payload.VehicleTypePropertyListResult)
                            {
                                //from the api get all the propertyid and names and store in different arrays                         
                                vehicleOtherPropertIds.Add(rec.VehicleTypePropertyId.ToString());
                                vehicleOtherPropertNames.Add(rec.VehiclePropertyName);
                            }
                        }
                    }

                    viewModel = new VehicleViewModel
                    {
                        Heading = "New Vehicle",
                        VehicleOtherPropertyIds = vehicleOtherPropertIds,
                        VehicleOtherPropertyNames = vehicleOtherPropertNames,
                        VehicleTypeId = 1
                    };

                    return View("VehicleForm", viewModel);
                }

                List<string> VehicleOtherProperties = new List<string>();

                string vProperty = "";
                int counter = 0;

                foreach (var rec in viewModel.VehicleOtherPropertyValuesIds.Split("|"))
                {
                    vProperty = rec + "|" + viewModel.VehicleOtherPropertyValues.Split("|")[counter];

                    VehicleOtherProperties.Add(vProperty);
                    counter++;
                }
                
                VehicleRequest vehicleRequest = new VehicleRequest();

                vehicleRequest.VehicleTypeId = viewModel.VehicleTypeId;
                vehicleRequest.Make = viewModel.Make;
                vehicleRequest.Model = viewModel.Model;
                vehicleRequest.VehicleOtherProperties = VehicleOtherProperties;               

                string postRequestUri = "/api/vehicle" ;

                //call api to save the vehicle record
                using (var request = new HttpRequestMessage(HttpMethod.Post, postRequestUri))
                {
                    var json = JsonConvert.SerializeObject(vehicleRequest);
                    using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        request.Content = stringContent;

                        using (var response = await client
                            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                            .ConfigureAwait(false))
                        {
                            response.EnsureSuccessStatusCode();
                        }
                    }
                }
                
                return View("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError("An Exception error was encountered : {ExceptionMessage}", ex.ToString());

                return View("Error");
            }            
        }

    }
}
