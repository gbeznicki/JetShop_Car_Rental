using CarRental.BusinessLogic.Vehicles;
using CarRental.Interfaces;
using NUnit.Framework;

namespace CarRental.UnitTests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTypeofCompact()
        {
            IVehicle vehicle = new Compact();
            Assert.IsInstanceOf(typeof(Compact), vehicle);
            Assert.IsNotInstanceOf(typeof(Minivan), vehicle);
            Assert.IsNotInstanceOf(typeof(Premium), vehicle);
        }

        [Test]
        public void TestTypeofMinivan()
        {
            IVehicle vehicle = new Minivan();
            Assert.IsInstanceOf(typeof(Minivan), vehicle);
            Assert.IsNotInstanceOf(typeof(Compact), vehicle);
            Assert.IsNotInstanceOf(typeof(Premium), vehicle);
        }

        [Test]
        public void TestTypeofPremium()
        {
            IVehicle vehicle = new Premium();
            Assert.IsInstanceOf(typeof(Premium), vehicle);
            Assert.IsNotInstanceOf(typeof(Minivan), vehicle);
            Assert.IsNotInstanceOf(typeof(Compact), vehicle);
        }

    }
}