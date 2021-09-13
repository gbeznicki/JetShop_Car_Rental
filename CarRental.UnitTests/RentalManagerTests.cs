using CarRental.BusinessLogic;
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
    public class RentalManagerTests
    {
        static readonly Container container;
        private IRentalManager rentalManager;

        static RentalManagerTests()
        {
            container = new Container();
            container.Register<IBookingNumberGenerator, BookingNumberGenerator>();
            container.Register<IOrderRepository, OrderRepository>();
            container.Register<IRentalManager, RentalManager>();
        }

        [SetUp]
        public void SetUp()
        {
            VehicleDictionary.LoadVehicles();
            rentalManager = container.GetInstance<IRentalManager>();
        }

        [Test]
        public void TestRental()
        {
            IRentOrder fcRentOrder = new FirstClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(11), VehicleCategory = "Minivan", VehicleId = "EL01234", SomeFirstClientRentProperty = "NotImportantString" };
            IRentOrder scRentOrder = new SecondClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(1), VehicleCategory = "Premium", VehicleId = "EL11234", SomeSecondClientRentProperty = 1 };

            Guid fcGuid = rentalManager.RentVehicle(fcRentOrder);
            Guid scGuid = rentalManager.RentVehicle(scRentOrder);

            Assert.IsTrue(fcGuid != Guid.Empty);
            Assert.IsTrue(scGuid != Guid.Empty);
            Assert.IsTrue(VehicleDictionary.Vehicles.Find(x => x.VehicleId == "EL01234").IsRented);
            Assert.IsTrue(VehicleDictionary.Vehicles.Find(x => x.VehicleId == "EL11234").IsRented);
        }

        [Test]
        public void TestSameCarRentalFail()
        {
            IRentOrder fcRentOrder = new FirstClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(11), VehicleCategory = "Minivan", VehicleId = "EL01234", SomeFirstClientRentProperty = "NotImportantString" };
            IRentOrder scRentOrder = new SecondClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(1), VehicleCategory = "Minivan", VehicleId = "EL01234", SomeSecondClientRentProperty = 1 };

            Guid fcGuid = rentalManager.RentVehicle(fcRentOrder);
            Guid scGuid = rentalManager.RentVehicle(scRentOrder);

            Assert.IsTrue(fcGuid != Guid.Empty);
            Assert.IsTrue(scGuid == Guid.Empty);
            Assert.IsTrue(VehicleDictionary.Vehicles.Find(x => x.VehicleId == "EL01234").IsRented);
        }

        [Test]
        public void TestRentalFailDate()
        {
            IRentOrder fcRentOrder = new FirstClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(-1), VehicleCategory = "Minivan", VehicleId = "EL01234", SomeFirstClientRentProperty = "NotImportantString" };

            Assert.Throws<CarRentalException>(() => rentalManager.RentVehicle(fcRentOrder));
            Assert.IsTrue(!VehicleDictionary.Vehicles.Find(x => x.VehicleId == "EL01234").IsRented);
        }


        [Test]
        public void TestReturn()
        {
            IRentOrder fcRentOrder = new FirstClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(1), VehicleCategory = "Minivan", VehicleId = "EL01234", SomeFirstClientRentProperty = "NotImportantString" };
            IRentOrder scRentOrder = new SecondClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(1), VehicleCategory = "Premium", VehicleId = "EL11234", SomeSecondClientRentProperty = 1 };

            Guid fcGuid = rentalManager.RentVehicle(fcRentOrder);
            Guid scGuid = rentalManager.RentVehicle(scRentOrder);

            IReturnOrder fcReturnOrder = new FirstClientReturnOrder { BookingNumber = fcGuid, ReturnDateTime = DateTime.Now.AddDays(3), ReturnMileage = 2000 };
            IReturnOrder scReturnOrder = new SecondClientReturnOrder { BookingNumber = scGuid, ReturnDateTime = DateTime.Now.AddDays(3), ReturnMileage = 3000 };

            decimal fcAmount = rentalManager.ReturnVehicle(fcReturnOrder);
            decimal scAmount = rentalManager.ReturnVehicle(scReturnOrder);

            Assert.IsTrue(fcGuid != Guid.Empty);
            Assert.IsTrue(scGuid != Guid.Empty);
            Assert.IsTrue(fcAmount > 0);
            Assert.IsTrue(scAmount > 0);
            Assert.IsTrue(!VehicleDictionary.Vehicles.Find(x => x.VehicleId == "EL01234").IsRented);
            Assert.IsTrue(!VehicleDictionary.Vehicles.Find(x => x.VehicleId == "EL11234").IsRented);
        }

        [Test]
        public void TestReturnFailDate()
        {
            IRentOrder fcRentOrder = new FirstClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(1), VehicleCategory = "Minivan", VehicleId = "EL01234", SomeFirstClientRentProperty = "NotImportantString" };
            Guid fcGuid = rentalManager.RentVehicle(fcRentOrder);

            IReturnOrder fcReturnOrder = new FirstClientReturnOrder { BookingNumber = fcGuid, ReturnDateTime = DateTime.Now.AddDays(-3), ReturnMileage = 2000 };

            Assert.Throws<CarRentalException>(() => rentalManager.ReturnVehicle(fcReturnOrder));
            Assert.IsTrue(VehicleDictionary.Vehicles.Find(x => x.VehicleId == "EL01234").IsRented);
        }

        [Test]
        public void TestReturnFailMileage()
        {
            IRentOrder fcRentOrder = new FirstClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(1), VehicleCategory = "Minivan", VehicleId = "EL01234", SomeFirstClientRentProperty = "NotImportantString" };
            Guid fcGuid = rentalManager.RentVehicle(fcRentOrder);

            IReturnOrder fcReturnOrder = new FirstClientReturnOrder { BookingNumber = fcGuid, ReturnDateTime = DateTime.Now.AddDays(10), ReturnMileage = 0 };

            Assert.Throws<CarRentalException>(() => rentalManager.ReturnVehicle(fcReturnOrder));
            Assert.IsTrue(VehicleDictionary.Vehicles.Find(x => x.VehicleId == "EL01234").IsRented);
        }

        [Test]
        public void TestReturnFailBookingNumber()
        {
            IRentOrder fcRentOrder = new FirstClientRentOrder { CustomersDateOfBirth = DateTime.Parse("1990-01-01"), RentalDateTime = DateTime.Now.AddDays(1), VehicleCategory = "Minivan", VehicleId = "EL01234", SomeFirstClientRentProperty = "NotImportantString" };
            Guid fcGuid = rentalManager.RentVehicle(fcRentOrder);

            IReturnOrder fcReturnOrder = new FirstClientReturnOrder { BookingNumber = Guid.Empty, ReturnDateTime = DateTime.Now.AddDays(10), ReturnMileage = 10000 };

            Assert.Throws<CarRentalException>(() => rentalManager.ReturnVehicle(fcReturnOrder));
            Assert.IsTrue(VehicleDictionary.Vehicles.Find(x => x.VehicleId == "EL01234").IsRented);
        }
    }
}
