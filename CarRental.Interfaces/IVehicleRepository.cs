
namespace CarRental.Interfaces
{
    public interface IVehicleRepository
    {
        IVehicle GetVehicleById(string vehicleId);
        string GetVehicleCategory(string vehicleId);
    }
}