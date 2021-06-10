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
            modelBuilder.Entity<OrderModel>()
                .HasOne(v => v.Vehicle)
                .WithMany(o => o.Orders);

            modelBuilder.Entity<VehicleModel>()
                .HasOne(vm => vm.VehicleCategory)
                .WithMany(vc => vc.Vehicles);

            modelBuilder.Entity<VehicleCategoryModel>().HasData(
                new VehicleCategoryModel { VehicleCategoryId = 1, VehicleCategoryName = "Compact" },
                new VehicleCategoryModel { VehicleCategoryId = 2, VehicleCategoryName = "Premium" },
                new VehicleCategoryModel { VehicleCategoryId = 3, VehicleCategoryName = "Minivan" });

            modelBuilder.Entity<VehicleModel>().HasData(
                new VehicleModel { VehicleCategoryId = 1, VehicleId = "EL01234" },
                new VehicleModel { VehicleCategoryId = 2, VehicleId = "EL11234" },
                new VehicleModel { VehicleCategoryId = 3, VehicleId = "EL21234" },
                new VehicleModel { VehicleCategoryId = 1, VehicleId = "EL31234" },
                new VehicleModel { VehicleCategoryId = 2, VehicleId = "EL41234" }
                );

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
                    => options.UseSqlite(@"Data Source=D:\Source\JetShop_Car_Rental\simpleDb.db");
    }
}
