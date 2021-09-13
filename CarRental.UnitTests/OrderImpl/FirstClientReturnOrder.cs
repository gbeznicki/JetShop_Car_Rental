using CarRental.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.UnitTests.OrderImpl
{
    class FirstClientReturnOrder : IReturnOrder
    {
        public Guid BookingNumber { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public int ReturnMileage { get; set; }
        public string SomeFirstClientReturnProperty { get; set; }

    }
}
