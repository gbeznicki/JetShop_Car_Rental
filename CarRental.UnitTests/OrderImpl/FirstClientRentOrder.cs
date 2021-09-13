using CarRental.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.UnitTests.OrderImpl
{
    public class FirstClientRentOrder : IRentOrder
    {
        public DateTime CustomersDateOfBirth { get; set; }
        public DateTime RentalDateTime { get; set; }
        public string VehicleId { get; set; }
        public string VehicleCategory { get; set; }
        public string SomeFirstClientRentProperty { get; set; }
    }
}
