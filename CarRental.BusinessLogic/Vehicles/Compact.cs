using CarRental.Common;
using CarRental.Interfaces;
using System;

namespace CarRental.BusinessLogic.Vehicles
{
    public class Compact : Vehicle
    {
        public Compact(decimal baseDayRental, decimal kilometerPrice, string vehicleId) : base(baseDayRental, kilometerPrice, vehicleId)
        {
        }

        public override CarCategory CarCategory => CarCategory.Compact;

        public override decimal GetCurrentRentCost(int numberOfDays, int numberOfKilometers)
        {
            if (!IsRented)
                return 0;

            return BaseDayRental * numberOfDays;
        }
    }
}
