using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    public partial class addedIsActiveFieldToConfigurationEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "sales",
                table: "Interiors",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "sales",
                table: "Gearbox",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "sales",
                table: "EquipmentVersion",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "sales",
                table: "Engine",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "sales",
                table: "Colors",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "sales",
                table: "CarModel",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "sales",
                table: "CarClass",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "sales",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "sales",
                table: "AdditionalEquipment",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "sales",
                table: "Interiors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "sales",
                table: "Gearbox");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "sales",
                table: "EquipmentVersion");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "sales",
                table: "Engine");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "sales",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "sales",
                table: "CarModel");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "sales",
                table: "CarClass");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "sales",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "sales",
                table: "AdditionalEquipment");
        }
    }
}
