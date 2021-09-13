using CarRental.Interfaces;
using System;

namespace CarRental.BusinessLogic.Vehicles
{
    public class Minivan : Vehicle
    {
        public Minivan(decimal baseDayRental, decimal kilometerPrice, string vehicleId, bool isRented) : base(baseDayRental, kilometerPrice, vehicleId, isRented)
        {
        }

        public override decimal GetCurrentRentCost(int numberOfDays, int numberOfKilometers)
        {
            if (!IsRented)
                return 0;

            return BaseDayRental * numberOfDays * 1.7m + (KilometerPrice * numberOfKilometers * 1.5m);
        }
    }
}
