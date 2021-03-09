using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using CarSales.Domain;

namespace CarSales.Persistence
{
    public partial class CarSalesContext : DbContext
    {
        public readonly ILogger _logger;

        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<VehicleProperty> VehicleProperties { get; set; }
        public virtual DbSet<VehicleTypeProperty> VehicleTypeProperties { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleOtherProperty> VehicleOtherProperties { get; set; }

        public CarSalesContext(DbContextOptions<CarSalesContext> options) : base(options) { }

    }
}
