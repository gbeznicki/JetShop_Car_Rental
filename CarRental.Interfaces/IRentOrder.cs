using RestSharp;
using System;

namespace CarRental.Interfaces
{
    public interface IRentOrder
    {
        public DateTime CustomersDateOfBirth { get; set; }
        public DateTime RentalDateTime { get; set; }
        public string VehicleId { get; set; }
        public string VehicleCategory { get; set; }
    }
}