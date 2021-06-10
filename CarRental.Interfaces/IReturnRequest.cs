using System;

namespace CarRental.Interfaces
{
    public interface IReturnRequest
    {
        public Guid BookingNumber { get; set; }
        public DateTime ReturnDateTime { get; set; }
    }
}