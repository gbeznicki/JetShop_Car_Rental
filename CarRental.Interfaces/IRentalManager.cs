using Microsoft.AspNetCore.Mvc;
using System;

namespace CarRental.Interfaces
{
    public interface IRentalManager
    {
        public Guid RentVehicle (IRentOrder rentRequest);
        public decimal ReturnVehicle(IReturnOrder returnRequest);
    }
}