using CarRental.Interfaces;
using System;

namespace CarRental.BusinessLogic.Vehicles
{
    public class Premium : Vehicle
    {
        public Premium(decimal baseDayRental, decimal kilometerPrice, IBookingNumberGenerator generator) : base(baseDayRental, kilometerPrice, generator)
        {
        }

        public override string Category => "Premium";

        public override decimal GetCurrentRentCost(int numberOfDays, int numberOfKilometers)
        {
            if (!IsRented)
                return 0;

            return BaseDayRental * numberOfDays * 1.2m + KilometerPrice * numberOfKilometers;
        }
    }
}
