using CarRental.Common;
using System;

namespace CarRental.Interfaces
{
    public interface IRentRequest
    {
        public DateTime CustomersDateOfBirth { get; set; }
        public DateTime RentalDateTime { get; set; }
        public string VehicleId { get; set; }
    }
}