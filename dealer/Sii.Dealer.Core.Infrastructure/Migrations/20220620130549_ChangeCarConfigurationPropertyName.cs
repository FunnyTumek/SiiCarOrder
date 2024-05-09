using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    public partial class ChangeCarConfigurationPropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "sales",
                table: "Interiors",
                newName: "Availability");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "sales",
                table: "Gearbox",
                newName: "Availability");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "sales",
                table: "EquipmentVersion",
                newName: "Availability");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "sales",
                table: "Engine",
                newName: "Availability");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "sales",
                table: "Colors",
                newName: "Availability");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "sales",
                table: "CarModel",
                newName: "Availability");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "sales",
                table: "CarClass",
                newName: "Availability");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "sales",
                table: "Brands",
                newName: "Availability");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "sales",
                table: "AdditionalEquipment",
                newName: "Availability");

            migrationBuilder.AddColumn<int>(
                name: "CarConfigurationId1",
                schema: "sales",
                table: "AdditionalEquipmentSet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalEquipmentSet_CarConfigurationId1",
                schema: "sales",
                table: "AdditionalEquipmentSet",
                column: "CarConfigurationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalEquipmentSet_CarConfiguration_CarConfigurationId1",
                schema: "sales",
                table: "AdditionalEquipmentSet",
                column: "CarConfigurationId1",
                principalSchema: "sales",
                principalTable: "CarConfiguration",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalEquipmentSet_CarConfiguration_CarConfigurationId1",
                schema: "sales",
                table: "AdditionalEquipmentSet");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalEquipmentSet_CarConfigurationId1",
                schema: "sales",
                table: "AdditionalEquipmentSet");

            migrationBuilder.DropColumn(
                name: "CarConfigurationId1",
                schema: "sales",
                table: "AdditionalEquipmentSet");

            migrationBuilder.RenameColumn(
                name: "Availability",
                schema: "sales",
                table: "Interiors",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Availability",
                schema: "sales",
                table: "Gearbox",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Availability",
                schema: "sales",
                table: "EquipmentVersion",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Availability",
                schema: "sales",
                table: "Engine",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Availability",
                schema: "sales",
                table: "Colors",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Availability",
                schema: "sales",
                table: "CarModel",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Availability",
                schema: "sales",
                table: "CarClass",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Availability",
                schema: "sales",
                table: "Brands",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Availability",
                schema: "sales",
                table: "AdditionalEquipment",
                newName: "IsActive");
        }
    }
}
