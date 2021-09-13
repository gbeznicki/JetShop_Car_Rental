using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Persistence.Migrations
{
    public partial class UpdatedVehicleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Vehicles_VehicleId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_VehicleId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "VehicleId1",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CurrentMileage",
                table: "Orders",
                newName: "RentalMileage");

            migrationBuilder.AddColumn<decimal>(
                name: "BaseDayRental",
                table: "Vehicles",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CurrentMileage",
                table: "Vehicles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsRented",
                table: "Vehicles",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "KilometerPrice",
                table: "Vehicles",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "VehicleId",
                table: "Orders",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Orders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReturnMileage",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VehicleId",
                table: "Orders",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Vehicles_VehicleId",
                table: "Orders",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Vehicles_VehicleId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_VehicleId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BaseDayRental",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CurrentMileage",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "IsRented",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "KilometerPrice",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReturnMileage",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "RentalMileage",
                table: "Orders",
                newName: "CurrentMileage");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleId1",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VehicleId1",
                table: "Orders",
                column: "VehicleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Vehicles_VehicleId1",
                table: "Orders",
                column: "VehicleId1",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
