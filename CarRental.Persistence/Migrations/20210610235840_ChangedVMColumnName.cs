using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Persistence.Migrations
{
    public partial class ChangedVMColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleCategories_CarCategoryId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "CarCategoryId",
                table: "Vehicles",
                newName: "VehicleCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_CarCategoryId",
                table: "Vehicles",
                newName: "IX_Vehicles_VehicleCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleCategories_VehicleCategoryId",
                table: "Vehicles",
                column: "VehicleCategoryId",
                principalTable: "VehicleCategories",
                principalColumn: "VehicleCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleCategories_VehicleCategoryId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "VehicleCategoryId",
                table: "Vehicles",
                newName: "CarCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_VehicleCategoryId",
                table: "Vehicles",
                newName: "IX_Vehicles_CarCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleCategories_CarCategoryId",
                table: "Vehicles",
                column: "CarCategoryId",
                principalTable: "VehicleCategories",
                principalColumn: "VehicleCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
