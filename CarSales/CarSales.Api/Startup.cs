using System.Text.Json.Serialization;
using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using CarSales.Persistence;
using CarSales.Application.Vehicles.Commands.CreateVehicle;
using CarSales.Application.OtherProperties.Commands.CreateVehicleOtherProperty;

using CarSales.Application.VehicleTypeProperties.Queries.GetVehicleTypePropertyList;


using CarSales.Api.Services;
using CarSales.Api.Interfaces;



namespace CarSales.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string AllowSpecificOrigins = "_allowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CarSalesContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CarSalesDBConnection"));
            }, ServiceLifetime.Transient);

            services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                 options.JsonSerializerOptions.PropertyNamingPolicy = null;
                 options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
             });

            services.AddMvc(option => option.EnableEndpointRouting = false);

            //for testing only, needs to be secured
            services.AddCors(options =>
            {
                options.AddPolicy(AllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:44371",                                        
                                        "http://localhost:54811",
                                        "http://localhost:5001"
                                        )
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();

                });
            });

            //for using mediatr
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Scoped objects are the same within a request, but different across different requests.                        
            services.AddScoped<ICreateVehicleCommand, CreateVehicleCommand>();
            services.AddScoped<ICreateVehicleOtherPropertyCommand, CreateVehicleOtherPropertyCommand>();
            services.AddScoped<IGetVehicleTypePropertyListQuery, GetVehicleTypePropertyListQuery>();

            //for registering interface and service
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IVehicleTypePropertyService, VehicleTypePropertyService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            //enable cross-origin request
            app.UseCors(AllowSpecificOrigins);

            app.UseMvc();
        }
    }
}
