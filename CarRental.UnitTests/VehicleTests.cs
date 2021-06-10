using CarRental.BusinessLogic;
using CarRental.BusinessLogic.Vehicles;
using CarRental.Interfaces;
using NUnit.Framework;
using SimpleInjector;

namespace CarRental.UnitTests
{
    [TestFixture]
    public class VehicleTests
    {
        static readonly Container container;


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestVehicleTypeof()
        {
            IVehicle compact = new Compact(0, 0, "c");
            IVehicle minivan = new Minivan(0, 0, "m");
            IVehicle premium = new Premium(0, 0, "P");

            Assert.IsInstanceOf(typeof(Compact), compact);
            Assert.IsNotInstanceOf(typeof(Minivan), compact);
            Assert.IsNotInstanceOf(typeof(Premium), compact);

            Assert.IsInstanceOf(typeof(Minivan), minivan);
            Assert.IsNotInstanceOf(typeof(Compact), minivan);
            Assert.IsNotInstanceOf(typeof(Premium), minivan);

            Assert.IsInstanceOf(typeof(Premium), premium);
            Assert.IsNotInstanceOf(typeof(Minivan), premium);
            Assert.IsNotInstanceOf(typeof(Compact), premium);
        }

        [Test]
        public void TestRent()
        {
            IVehicle vehicle = new Compact(10, 5, "c");

            bool rentalResult = vehicle.Rent();

            Assert.That(rentalResult);
            Assert.That(vehicle.IsRented);
        }

        [Test]
        public void TestRentFail()
        {
            IVehicle vehicle = new Compact(10, 5, "c");

            vehicle.Rent();

            bool rentalResult = vehicle.Rent();

            Assert.That(rentalResult == false);
            Assert.That(vehicle.IsRented);
        }

        [Test]
        public void TestSameDayReturnFail()
        {
            IVehicle vehicle = new Compact(10, 5, "c");

            vehicle.Rent();

            Assert.Throws(typeof(CarRentalException), () => vehicle.Return(100));
        }

        [Test]
        public void TestCurrentRentCostCalculationNotRented()
        {
            IVehicle compact = new Compact(0, 0, "c");
            IVehicle minivan = new Minivan(0, 0, "m");
            IVehicle premium = new Premium(0, 0, "P");

            int rentDays = 2;
            int kilometersDriven = 10;

            decimal compactRentCost = compact.GetCurrentRentCost(rentDays, kilometersDriven);
            decimal minivanRentCost = minivan.GetCurrentRentCost(rentDays, kilometersDriven);
            decimal premiumRentCost = premium.GetCurrentRentCost(rentDays, kilometersDriven);

            Assert.AreEqual(compactRentCost, 0);
            Assert.AreEqual(minivanRentCost, 0);
            Assert.AreEqual(premiumRentCost, 0);
        }

        [Test]
        public void TestCurrentRentCostCalculation()
        {
            IVehicle compact = new Compact(0, 0, "c");
            IVehicle minivan = new Minivan(0, 0, "m");
            IVehicle premium = new Premium(0, 0, "P");

            compact.Rent();
            minivan.Rent();
            premium.Rent();

            int rentDays = 2;
            int kilometersDriven = 10;

            decimal compactRentCost = compact.GetCurrentRentCost(rentDays, kilometersDriven);
            decimal minivanRentCost = minivan.GetCurrentRentCost(rentDays, kilometersDriven);
            decimal premiumRentCost = premium.GetCurrentRentCost(rentDays, kilometersDriven);

            Assert.AreEqual(compactRentCost, 20);
            Assert.AreEqual(minivanRentCost, 109);
            Assert.AreEqual(premiumRentCost, 74);
        }





    }
}