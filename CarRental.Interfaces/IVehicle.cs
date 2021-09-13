using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Interfaces
{
    public interface IVehicle
    {
        bool Rent(DateTime rentDate);
        decimal Return(DateTime returnDate, int numberOfKilometers);
        decimal GetCurrentRentCost(int numberOfDays, int numberOfKilometers);
        public decimal BaseDayRental { get; }
        public decimal KilometerPrice { get; }
        public bool IsRented { get; }
        public string VehicleId { get; }
    }
}
