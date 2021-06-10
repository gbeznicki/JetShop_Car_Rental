using CarRental.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.BusinessLogic
{
    public class BookingNumberGenerator : IBookingNumberGenerator
    {
        public Guid GenerateBookingNumber()
        {
            return Guid.NewGuid();
        }
    }
}
