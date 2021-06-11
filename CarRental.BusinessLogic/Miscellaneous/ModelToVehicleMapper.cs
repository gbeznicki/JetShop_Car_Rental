using CarRental.BusinessLogic.Vehicles;
using CarRental.Interfaces;
using CarRental.Persistence;

namespace CarRental.BusinessLogic.Miscellaneous
{
    public static class ModelToVehicleMapper
    {
        public static IVehicle MapModelToVehicle(VehicleModel model)
        {
            switch (model.VehicleCategory.VehicleCategoryName)
            {
                case "Minivan":
                    return new Minivan(model.BaseDayRental, model.KilometerPrice, model.VehicleId, model.IsRented);
                case "Premium":
                    return new Premium(model.BaseDayRental, model.KilometerPrice, model.VehicleId, model.IsRented);
                case "Compact":
                    return new Compact(model.BaseDayRental, model.KilometerPrice, model.VehicleId, model.IsRented);
            }
            return null;
        }
    }
}