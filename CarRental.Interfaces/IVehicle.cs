using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Interfaces
{
    public interface IVehicle
    {
        bool Rent();
        string GetReservationNumber();
        decimal Return();
    }
}
