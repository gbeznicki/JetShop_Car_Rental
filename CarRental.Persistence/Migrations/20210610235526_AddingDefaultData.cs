using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Persistence.Migrations
{
    public partial class AddingDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Vehicles_VehicleId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleCategories_CarCategoryVehicleCategoryId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CarCategoryVehicleCategoryId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Orders_VehicleId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CarCategoryVehicleCategoryId",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "CarCategoryId",
                table: "Vehicles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "VehicleCategories",
                columns: new[] { "VehicleCategoryId", "VehicleCategoryName" },
                values: new object[] { 1, "Compact" });

            migrationBuilder.InsertData(
                table: "VehicleCategories",
                columns: new[] { "VehicleCategoryId", "VehicleCategoryName" },
                values: new object[] { 2, "Premium" });

            migrationBuilder.InsertData(
                table: "VehicleCategories",
                columns: new[] { "VehicleCategoryId", "VehicleCategoryName" },
                values: new object[] { 3, "Minivan" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "CarCategoryId" },
                values: new object[] { "EL01234", 1 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "CarCategoryId" },
                values: new object[] { "EL31234", 1 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "CarCategoryId" },
                values: new object[] { "EL11234", 2 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "CarCategoryId" },
                values: new object[] { "EL41234", 2 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "CarCategoryId" },
                values: new object[] { "EL21234", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CarCategoryId",
                table: "Vehicles",
                column: "CarCategoryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleCategories_CarCategoryId",
                table: "Vehicles",
                column: "CarCategoryId",
                principalTable: "VehicleCategories",
                principalColumn: "VehicleCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Vehicles_VehicleId1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleCategories_CarCategoryId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CarCategoryId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Orders_VehicleId1",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "EL01234");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "EL11234");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "EL21234");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "EL31234");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "EL41234");

            migrationBuilder.DeleteData(
                table: "VehicleCategories",
                keyColumn: "VehicleCategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleCategories",
                keyColumn: "VehicleCategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleCategories",
                keyColumn: "VehicleCategoryId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CarCategoryId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleId1",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "CarCategoryVehicleCategoryId",
                table: "Vehicles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VehicleId",
                table: "Orders",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CarCategoryVehicleCategoryId",
                table: "Vehicles",
                column: "CarCategoryVehicleCategoryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleCategories_CarCategoryVehicleCategoryId",
                table: "Vehicles",
                column: "CarCategoryVehicleCategoryId",
                principalTable: "VehicleCategories",
                principalColumn: "VehicleCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
