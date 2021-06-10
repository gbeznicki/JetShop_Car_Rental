using CarRental.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.BusinessLogic.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        #region PrivateFields
        private readonly decimal baseDayRental;
        private readonly decimal kilometerPrice;
        protected DateTime rentDate;
        private readonly object locker = new object();
        protected bool isRented = false;
        private readonly string vehicleId;
        
        #endregion

        protected Vehicle(decimal baseDayRental, decimal kilometerPrice, string vehicleId)
        {
            this.baseDayRental = baseDayRental;
            this.kilometerPrice = kilometerPrice;
            this.vehicleId = vehicleId;
        }

        #region Properties
        public bool IsRented => isRented;
        public decimal BaseDayRental => baseDayRental;
        public decimal KilometerPrice => kilometerPrice;
        public string VehicleId => vehicleId;
        #endregion
        public abstract decimal GetCurrentRentCost(int numberOfDays, int numberOfKilometers);
        public bool Rent()
        {
            if (!IsRented)
            {
                lock (locker)
                {
                    if (!IsRented)
                    {
                        rentDate = DateTime.Now;
                        isRented = true;
                        return true;
                    }
                }
            }

            return false;
        }
        public decimal Return(int numberOfKilometers)
        {
            if (!IsRented)
                throw new CarRentalException("Can't return a vehicle that has not been rented");
            if (numberOfKilometers <= 0)
                throw new CarRentalException("Number of kilometers must be greater than 0");

            int numberOfDays = (DateTime.Now.Date - rentDate.Date).Days;

            if (numberOfDays <= 0)
                throw new CarRentalException("Car must be rented for at least 1 day");

            decimal totalRentCost = GetCurrentRentCost(numberOfDays, numberOfKilometers);

            if (totalRentCost <= 0)
                throw new CarRentalException("Total rent cost must be greater than 0");

            isRented = false;

            return totalRentCost;
        }
    }
}
