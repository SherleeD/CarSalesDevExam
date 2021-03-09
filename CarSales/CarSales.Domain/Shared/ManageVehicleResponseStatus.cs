
namespace CarSales.Domain.Shared
{
    public static class ManageVehicleResponseStatus
    {
        public static string Created = "Vehicle successfully created.";
        public static string CreateFailed = "Create vehicle request failed.";
        public static string NoVehicleTypeId = "No vehicle type id found.";
        public static string NoMakeFound = "No make found.";
        public static string NoModelFound = "No model found.";
    }


    public static class ManageVehicleTypePropertiesResponseStatus
    {        
        public static string NoVehicleTypeId = "No vehicle type id found.";
        public static string VehicleTypePropertyListRetrieveFailed = "Error retrieving vehicle type properties.";
        public static string VehicleTypePropertyListRetrieveSuccessful = "Vehicle type property list retrieve successful";

    }

}
