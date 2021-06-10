using CarRental.Interfaces;
using System;

namespace CarRental.BusinessLogic.Vehicles
{
    public class Compact : Vehicle
    {
        public Compact(decimal baseDayRental, decimal kilometerPrice, IBookingNumberGenerator generator) : base(baseDayRental, kilometerPrice, generator)
        {
        }

        public override string Category => "Compact";

        public override decimal GetCurrentRentCost(int numberOfDays, int numberOfKilometers)
        {
            if (!IsRented)
                return 0;

            return BaseDayRental * numberOfDays;
        }
    }
}
