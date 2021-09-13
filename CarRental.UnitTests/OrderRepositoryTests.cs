using CarRental.BusinessLogic.Miscellaneous;
using CarRental.BusinessLogic.Repositories;
using CarRental.BusinessLogic.Vehicles;
using CarRental.Interfaces;
using CarRental.UnitTests.OrderImpl;
using NUnit.Framework;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.UnitTests
{
    [TestFixture]
    public class OrderRepositoryTests
    {
        static readonly Container container;
        private IOrderRepository orderRepository;

        static OrderRepositoryTests()
        {
            container = new Container();
            container.Register<IBookingNumberGenerator, BookingNumberGenerator>();
            container.Register<IOrderRepository, OrderRepository>();
        }

        [SetUp]
        public void SetUp()
        {
            VehicleDictionary.LoadVehicles();
            orderRepository = container.GetInstance<IOrderRepository>();
        }

        [Test]
        public void TestCreateOrder()
        {
            IRentOrder rentOrder = new FirstClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(1), VehicleCategory = "Minivan", VehicleId = "EL01234", SomeFirstClientRentProperty = "NotImportantString" };
            Guid bookingId = orderRepository.CreateOrder(rentOrder);

            Assert.That(bookingId != Guid.Empty);
            Assert.IsTrue(VehicleDictionary.Vehicles.Find(x => x.VehicleId == "EL01234").IsRented);
        }

        [Test]
        public void TestCreateOrderFailDate()
        {
            IRentOrder rentOrder = new FirstClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(-1), VehicleCategory = "Minivan", VehicleId = "EL01234", SomeFirstClientRentProperty = "NotImportantString" };

            Assert.Throws<CarRentalException>(() => orderRepository.CreateOrder(rentOrder));
            Assert.IsTrue(!VehicleDictionary.Vehicles.Find(x => x.VehicleId == "EL01234").IsRented);
        }


        [Test]
        public void TestCreateOrderFailVechicleId()
        {
            IRentOrder rentOrder = new FirstClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(-1), VehicleCategory = "Minivan", VehicleId = "", SomeFirstClientRentProperty = "NotImportantString" };

            Assert.Throws<CarRentalException>(() => orderRepository.CreateOrder(rentOrder));
            Assert.IsTrue(!VehicleDictionary.Vehicles.Find(x => x.VehicleId == "EL01234").IsRented);
        }

        [Test]
        public void TestCloseOrder()
        {
            IRentOrder rentOrder = new FirstClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(1), VehicleCategory = "Minivan", VehicleId = "EL01234", SomeFirstClientRentProperty = "NotImportantString" };
            Guid bookingId = orderRepository.CreateOrder(rentOrder);

            IReturnOrder returnOrder = new FirstClientReturnOrder { BookingNumber = bookingId, ReturnDateTime = DateTime.Now.AddDays(3), ReturnMileage = 1000 };
            decimal amountToPay = orderRepository.CloseOrder(returnOrder);

            Assert.That(amountToPay > 0);
            Assert.IsTrue(!VehicleDictionary.Vehicles.Find(x => x.VehicleId == "EL01234").IsRented);
        }

        [Test]
        public void TestCloseOrderFailDays()
        {
            IRentOrder rentOrder = new FirstClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(1), VehicleCategory = "Minivan", VehicleId = "EL01234", SomeFirstClientRentProperty = "NotImportantString" };
            Guid bookingId = orderRepository.CreateOrder(rentOrder);

            IReturnOrder returnOrder = new FirstClientReturnOrder { BookingNumber = bookingId, ReturnDateTime = DateTime.Now.AddDays(-1), ReturnMileage = 1000 };

            Assert.Throws<CarRentalException>(() => orderRepository.CloseOrder(returnOrder));
            Assert.IsTrue(VehicleDictionary.Vehicles.Find(x => x.VehicleId == "EL01234").IsRented);
        }

        [Test]
        public void TestCloseOrderFailMileage()
        {
            IRentOrder rentOrder = new FirstClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(1), VehicleCategory = "Minivan", VehicleId = "EL01234", SomeFirstClientRentProperty = "NotImportantString" };
            Guid bookingId = orderRepository.CreateOrder(rentOrder);

            IReturnOrder returnOrder = new FirstClientReturnOrder { BookingNumber = bookingId, ReturnDateTime = DateTime.Now.AddDays(3), ReturnMileage = 0 };

            Assert.Throws<CarRentalException>(() => orderRepository.CloseOrder(returnOrder));
            Assert.IsTrue(VehicleDictionary.Vehicles.Find(x => x.VehicleId == "EL01234").IsRented);
        }

        [Test]
        public void TestCloseOrderFailBookingNr()
        {
            IRentOrder rentOrder = new FirstClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(1), VehicleCategory = "Minivan", VehicleId = "EL01234", SomeFirstClientRentProperty = "NotImportantString" };
            Guid bookingId = orderRepository.CreateOrder(rentOrder);

            IReturnOrder returnOrder = new FirstClientReturnOrder { BookingNumber = Guid.Empty, ReturnDateTime = DateTime.Now.AddDays(3), ReturnMileage = 0 };

            Assert.Throws<CarRentalException>(() => orderRepository.CloseOrder(returnOrder));
            Assert.IsTrue(VehicleDictionary.Vehicles.Find(x => x.VehicleId == "EL01234").IsRented);
        }

    }
}
