using CarRental.Interfaces;
using CarRental.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CarRental.BusinessLogic.Miscellaneous
{
    public static class VehicleDictionary
    {
        private static List<IVehicle> vehicles;

        public static List<IVehicle> Vehicles => vehicles;

        public static void LoadVehicles()
        {
            using (CarRentalDbContext carRentalDbContext = new CarRentalDbContext())
            {
                vehicles = new List<IVehicle>();
                IEnumerable<VehicleModel> vehicleModels = carRentalDbContext.Vehicles;
                foreach (VehicleModel model in vehicleModels)
                {
                    IVehicle v = ModelToVehicleMapper.MapModelToVehicle(model);
                    vehicles.Add(v);
                }
            }
        }
    }
}
