using CarRental.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Interfaces
{
    public interface IVehicle
    {
        bool Rent();
        decimal Return(int numberOfKilometers);
        decimal GetCurrentRentCost(int numberOfDays, int numberOfKilometers);
        public decimal BaseDayRental { get; }
        public decimal KilometerPrice { get; }
        public bool IsRented { get; }
        public CarCategory CarCategory { get; }
    }
}
