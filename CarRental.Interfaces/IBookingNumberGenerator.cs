using System;

namespace CarRental.Interfaces
{
    public interface IBookingNumberGenerator
    {
        Guid GenerateBookingNumber();
    }
}