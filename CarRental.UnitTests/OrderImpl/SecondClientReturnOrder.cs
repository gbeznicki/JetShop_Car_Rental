using CarRental.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.UnitTests.OrderImpl
{
    public class SecondClientReturnOrder : IReturnOrder
    {
        public Guid BookingNumber { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public int ReturnMileage { get; set; }
        public int SomeSecondClientReturnProperty { get; set; }
    }
}
