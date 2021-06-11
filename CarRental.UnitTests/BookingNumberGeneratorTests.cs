using CarRental.BusinessLogic;
using CarRental.BusinessLogic.Miscellaneous;
using CarRental.BusinessLogic.Vehicles;
using CarRental.Interfaces;
using NUnit.Framework;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.UnitTests
{
    [TestFixture]
    public class BookingNumberGeneratorTests
    {
        static readonly Container container;

        static BookingNumberGeneratorTests()
        {
            container = new Container();
            container.Register<IBookingNumberGenerator, BookingNumberGenerator>();
        }

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void TestBNGeneration()
        {
            IBookingNumberGenerator bookingNumberGenerator = container.GetInstance<IBookingNumberGenerator>();
            
            Guid bookingNumber = bookingNumberGenerator.GenerateBookingNumber();

            Assert.IsNotNull(bookingNumber);
            Assert.IsNotEmpty(bookingNumber.ToString());
        }
    }
}
