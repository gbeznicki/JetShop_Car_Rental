﻿using CarRental.BusinessLogic.Miscellaneous;
using CarRental.BusinessLogic.Vehicles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.UnitTests
{
    [TestFixture]
    public class RentalManagerTests
    {
        [SetUp]
        public void SetUp()
        {
            VehicleDictionary.LoadVehicles();
        }

        [Test]
        public void TestRental()
        {
            Assert.Fail();
        }

        [Test]
        public void TestReturn()
        {
            Assert.Fail();
        }
    }
}
