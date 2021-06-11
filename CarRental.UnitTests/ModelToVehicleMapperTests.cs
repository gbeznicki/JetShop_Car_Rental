using CarRental.BusinessLogic.Miscellaneous;
using CarRental.BusinessLogic.Vehicles;
using CarRental.Interfaces;
using CarRental.Persistence;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.UnitTests
{
    [TestFixture]
    public class ModelToVehicleMapperTests
    {
        [Test]
        public void TestMapping()
        {
            VehicleModel minivanModel = new VehicleModel()
            {
                BaseDayRental = 1,
                CurrentMileage = 1,
                IsRented = false,
                KilometerPrice = 1,
                VehicleCategory = new VehicleCategoryModel() { VehicleCategoryId = 3, VehicleCategoryName = "Minivan" },
                VehicleId = "EL0001"
            };


            VehicleModel compactModel = new VehicleModel()
            {
                BaseDayRental = 1,
                CurrentMileage = 1,
                IsRented = false,
                KilometerPrice = 1,
                VehicleCategory = new VehicleCategoryModel() { VehicleCategoryId = 1, VehicleCategoryName = "Compact" },
                VehicleId = "EL0002"
            };

            
            VehicleModel premiumModel = new VehicleModel()
            {
                BaseDayRental = 1,
                CurrentMileage = 1,
                IsRented = false,
                KilometerPrice = 1,
                VehicleCategory = new VehicleCategoryModel() { VehicleCategoryId = 2, VehicleCategoryName = "Premium" },
                VehicleId = "EL0003"
            };

            IVehicle minivan = ModelToVehicleMapper.MapModelToVehicle(minivanModel);
            IVehicle compact = ModelToVehicleMapper.MapModelToVehicle(compactModel);
            IVehicle premium = ModelToVehicleMapper.MapModelToVehicle(premiumModel);

            Assert.IsInstanceOf<Minivan>(minivan);
            Assert.IsNotInstanceOf<Premium>(minivan);
            Assert.IsNotInstanceOf<Compact>(minivan);

            Assert.IsNotInstanceOf<Minivan>(compact);
            Assert.IsNotInstanceOf<Premium>(compact);
            Assert.IsInstanceOf<Compact>(compact);

            Assert.IsNotInstanceOf<Minivan>(premium);
            Assert.IsInstanceOf<Premium>(premium);
            Assert.IsNotInstanceOf<Compact>(premium);

        }
    }
}
