using System;

namespace CarRental.Interfaces
{
    public interface IReturnOrder
    {
        public Guid BookingNumber { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public int  ReturnMileage { get; set; }
    }
}