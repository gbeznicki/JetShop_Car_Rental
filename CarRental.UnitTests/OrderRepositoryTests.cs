using CarRental.BusinessLogic.Miscellaneous;
using CarRental.BusinessLogic.Vehicles;
using CarRental.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.UnitTests
{
    [TestFixture]
    public class OrderRepositoryTests
    {
        [SetUp]
        public void SetUp()
        {
            VehicleDictionary.LoadVehicles();
        }
    }
}
