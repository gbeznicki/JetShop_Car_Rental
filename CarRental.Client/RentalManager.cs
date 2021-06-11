using CarRental.BusinessLogic.Miscellaneous;
using CarRental.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.BusinessLogic
{
    public class RentalManager : IRentalManager
    {
        private readonly IOrderRepository orderRepository;

        public RentalManager(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Guid RentVehicle(IOrder rentRequest)
        {
            try
            {
                Guid bookingNumber = orderRepository.CreateOrder(rentRequest);
                return bookingNumber;
            }
            catch
            {
                throw;
            }
        }

        public decimal ReturnVehicle(IReturnOrder returnRequest)
        {
            try
            {
                decimal amount = orderRepository.CloseOrder(returnRequest);
                return amount;
            }
            catch
            {
                throw;
            }
        }
    }
}
