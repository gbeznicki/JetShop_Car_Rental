using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Persistence.Migrations
{
    public partial class UpdatedVehicleModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "EL01234",
                columns: new[] { "BaseDayRental", "CurrentMileage", "KilometerPrice" },
                values: new object[] { 1m, 1, 1m });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "EL11234",
                columns: new[] { "BaseDayRental", "CurrentMileage", "KilometerPrice" },
                values: new object[] { 2m, 100, 10m });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "EL21234",
                columns: new[] { "BaseDayRental", "CurrentMileage", "KilometerPrice" },
                values: new object[] { 100m, 1010, 5m });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "EL31234",
                columns: new[] { "BaseDayRental", "CurrentMileage", "KilometerPrice" },
                values: new object[] { 75m, 5, 50m });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "EL41234",
                columns: new[] { "BaseDayRental", "KilometerPrice" },
                values: new object[] { 15m, 20m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "EL01234",
                columns: new[] { "BaseDayRental", "CurrentMileage", "KilometerPrice" },
                values: new object[] { 0m, 0, 0m });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "EL11234",
                columns: new[] { "BaseDayRental", "CurrentMileage", "KilometerPrice" },
                values: new object[] { 0m, 0, 0m });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "EL21234",
                columns: new[] { "BaseDayRental", "CurrentMileage", "KilometerPrice" },
                values: new object[] { 0m, 0, 0m });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "EL31234",
                columns: new[] { "BaseDayRental", "CurrentMileage", "KilometerPrice" },
                values: new object[] { 0m, 0, 0m });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "EL41234",
                columns: new[] { "BaseDayRental", "KilometerPrice" },
                values: new object[] { 0m, 0m });
        }
    }
}
