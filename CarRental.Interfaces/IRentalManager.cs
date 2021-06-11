using Microsoft.AspNetCore.Mvc;
using System;

namespace CarRental.Interfaces
{
    public interface IRentalManager
    {
        public Guid RentVehicle (IOrder rentRequest);
        public decimal ReturnVehicle(IReturnOrder returnRequest);
    }
}