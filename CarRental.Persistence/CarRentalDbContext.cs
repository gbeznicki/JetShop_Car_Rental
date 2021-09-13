using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Persistence
{
    public class CarRentalDbContext : DbContext
    {
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<VehicleCategoryModel> VehicleCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            VehicleCategoryModel compacCat = new VehicleCategoryModel { VehicleCategoryId = 1, VehicleCategoryName = "Compact" };
            VehicleCategoryModel premiumCat = new VehicleCategoryModel { VehicleCategoryId = 2, VehicleCategoryName = "Premium" };
            VehicleCategoryModel minivanCat = new VehicleCategoryModel { VehicleCategoryId = 3, VehicleCategoryName = "Minivan" };

            modelBuilder.Entity<VehicleCategoryModel>().HasData(compacCat, premiumCat, minivanCat);

            modelBuilder.Entity<VehicleModel>().HasData(
                new VehicleModel { VehicleCategoryId = 1, VehicleId = "EL01234", BaseDayRental = 1m, CurrentMileage = 1, IsRented = false, KilometerPrice = 1m },
                new VehicleModel { VehicleCategoryId = 2, VehicleId = "EL11234", BaseDayRental = 2m, CurrentMileage = 100, IsRented = false, KilometerPrice = 10m },
                new VehicleModel { VehicleCategoryId = 3, VehicleId = "EL21234", BaseDayRental = 100m, CurrentMileage = 1010, IsRented = false, KilometerPrice = 5m },
                new VehicleModel { VehicleCategoryId = 1, VehicleId = "EL31234", BaseDayRental = 75m, CurrentMileage = 5, IsRented = false, KilometerPrice = 50m },
                new VehicleModel { VehicleCategoryId = 2, VehicleId = "EL41234", BaseDayRental = 15m, CurrentMileage = 0, IsRented = false, KilometerPrice = 20m }
                );

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
                    => options.UseSqlite(@"Data Source=D:\Source\JetShop_Car_Rental\simpleDb.db");
    }
}
