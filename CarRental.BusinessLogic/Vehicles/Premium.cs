using CarRental.Interfaces;
using System;

namespace CarRental.BusinessLogic.Vehicles
{
    public class Premium : Vehicle
    {
        public Premium(decimal baseDayRental, decimal kilometerPrice) : base(baseDayRental, kilometerPrice)
        {
        }

        public override decimal GetCurrentRentCost(int numberOfDays, int numberOfKilometers)
        {
            if (!IsRented)
                return 0;

            return BaseDayRental * numberOfDays * 1.2m + KilometerPrice * numberOfKilometers;
        }
    }
}
