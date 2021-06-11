using CarRental.BusinessLogic.Miscellaneous;
using CarRental.BusinessLogic.Vehicles;
using CarRental.Interfaces;
using CarRental.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.BusinessLogic.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IBookingNumberGenerator bookingNumberGenerator;
        private readonly CarRentalDbContext dbContext;

        public OrderRepository(IBookingNumberGenerator bookingNumberGenerator)
        {
            this.bookingNumberGenerator = bookingNumberGenerator;
            dbContext = new CarRentalDbContext();
        }

        public decimal CloseOrder(IReturnOrder order)
        {
            if (order.BookingNumber == Guid.Empty)
                throw new CarRentalException("No order selected for closing");

            OrderModel orderModel = dbContext.Orders.Find(order.BookingNumber);

            if (orderModel == null)
                throw new CarRentalException("No order found by given order number");

            VehicleModel vehicleModel = orderModel.Vehicle;

            IVehicle vehicleToReturn = VehicleDictionary.Vehicles.Find(x => x.VehicleId == vehicleModel.VehicleId);
            int numberOfKilometers = order.ReturnMileage - orderModel.RentalMileage;

            decimal rentCost = vehicleToReturn.Return(order.ReturnDateTime, numberOfKilometers);

            orderModel.ReturnDate = order.ReturnDateTime;
            orderModel.ReturnMileage = order.ReturnMileage;
            dbContext.Orders.Update(orderModel);

            vehicleModel.IsRented = false;
            dbContext.Vehicles.Update(vehicleModel);

            return rentCost;
        }

        public Guid CreateOrder(IOrder order)
        {
            if (order.RentalDateTime < DateTime.Now)
                throw new CarRentalException("Car rental date can't be from the past");
            if (string.IsNullOrEmpty(order.VehicleId))
                throw new CarRentalException("No car selected for rental");

            VehicleModel vehicleToRent = dbContext.Vehicles.Find(order.VehicleId);
            
            if (vehicleToRent == null)
                throw new CarRentalException("Invalid vehicleId");

            IVehicle vehicle = VehicleDictionary.Vehicles.Find(x => x.VehicleId == vehicleToRent.VehicleId);

            if (vehicle.Rent(order.RentalDateTime)) 
            {
                Guid bookingNumber = bookingNumberGenerator.GenerateBookingNumber();
                OrderModel orderModel = new OrderModel()
                {
                    BookingNumber = bookingNumber,
                    CustomerDateOfBirth = order.CustomersDateOfBirth,
                    RentalDate = order.RentalDateTime,
                    RentalMileage = vehicleToRent.CurrentMileage,
                    OrderDate = DateTime.Now,
                    Vehicle = vehicleToRent,
                    VehicleId = vehicleToRent.VehicleId
                };
                dbContext.Add(orderModel);
                dbContext.SaveChanges();
                return bookingNumber;
            }
            else
            {
                return Guid.Empty;
            }

        }
    }
}
