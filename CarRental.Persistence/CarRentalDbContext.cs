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
                .HasOne(vm => vm.CarCategory)
                .WithMany(vc => vc.Vehicles);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
                    => options.UseSqlite(@"Data Source=D:\Source\JetShop_Car_Rental\simpleDb.db");
    }
}
