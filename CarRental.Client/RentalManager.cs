using CarRental.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.BusinessLogic
{
    public class RentalManager : IRentalManager
    {
        private readonly IBookingNumberGenerator bookingNumberGenerator;

        public RentalManager(IBookingNumberGenerator bookingNumberGenerator)
        {
            this.bookingNumberGenerator = bookingNumberGenerator;
        }

        public IRentResponse RentVehicle(IRentRequest rentRequest)
        {
            Guid bookingNumber = bookingNumberGenerator.GenerateBookingNumber();
        }

        public IReturnResponse ReturnVehicle(IReturnRequest returnRequest)
        {
            throw new NotImplementedException();
        }
    }
}
