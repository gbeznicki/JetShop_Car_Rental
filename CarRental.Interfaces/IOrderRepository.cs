using CarRental.Persistence;
using System;

namespace CarRental.Interfaces
{
    public interface IOrderRepository
    {
        public Guid CreateOrder(IOrder order);
        public decimal CloseOrder(IReturnOrder order);        
    }
}