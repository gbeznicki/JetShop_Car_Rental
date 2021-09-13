using CarRental.Persistence;
using System;

namespace CarRental.Interfaces
{
    public interface IOrderRepository
    {
        public Guid CreateOrder(IRentOrder order);
        public decimal CloseOrder(IReturnOrder order);        
    }
}