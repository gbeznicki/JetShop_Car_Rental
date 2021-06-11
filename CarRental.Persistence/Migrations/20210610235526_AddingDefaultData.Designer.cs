﻿// <auto-generated />
using System;
using CarRental.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRental.Persistence.Migrations
{
    [DbContext(typeof(CarRentalDbContext))]
    [Migration("20210610235526_AddingDefaultData")]
    partial class AddingDefaultData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("CarRental.Persistence.OrderModel", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("BookingNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("CurrentMileage")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CustomerDateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VehicleId1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId");

                    b.HasIndex("VehicleId1");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CarRental.Persistence.VehicleCategoryModel", b =>
                {
                    b.Property<int>("VehicleCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("VehicleCategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("VehicleCategoryId");

                    b.ToTable("VehicleCategories");

                    b.HasData(
                        new
                        {
                            VehicleCategoryId = 1,
                            VehicleCategoryName = "Compact"
                        },
                        new
                        {
                            VehicleCategoryId = 2,
                            VehicleCategoryName = "Premium"
                        },
                        new
                        {
                            VehicleCategoryId = 3,
                            VehicleCategoryName = "Minivan"
                        });
                });

            modelBuilder.Entity("CarRental.Persistence.VehicleModel", b =>
                {
                    b.Property<string>("VehicleId")
                        .HasColumnType("TEXT");

                    b.Property<int>("CarCategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("VehicleId");

                    b.HasIndex("CarCategoryId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            VehicleId = "EL01234",
                            CarCategoryId = 1
                        },
                        new
                        {
                            VehicleId = "EL11234",
                            CarCategoryId = 2
                        },
                        new
                        {
                            VehicleId = "EL21234",
                            CarCategoryId = 3
                        },
                        new
                        {
                            VehicleId = "EL31234",
                            CarCategoryId = 1
                        },
                        new
                        {
                            VehicleId = "EL41234",
                            CarCategoryId = 2
                        });
                });

            modelBuilder.Entity("CarRental.Persistence.OrderModel", b =>
                {
                    b.HasOne("CarRental.Persistence.VehicleModel", "Vehicle")
                        .WithMany("Orders")
                        .HasForeignKey("VehicleId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("CarRental.Persistence.VehicleModel", b =>
                {
                    b.HasOne("CarRental.Persistence.VehicleCategoryModel", "CarCategory")
                        .WithMany("Vehicles")
                        .HasForeignKey("CarCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarCategory");
                });

            modelBuilder.Entity("CarRental.Persistence.VehicleCategoryModel", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("CarRental.Persistence.VehicleModel", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}