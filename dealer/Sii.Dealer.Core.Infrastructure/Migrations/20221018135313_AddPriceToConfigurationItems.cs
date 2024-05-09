using Microsoft.EntityFrameworkCore.Migrations;
using Sii.Dealer.SharedKernel.Migrations;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    public partial class AddPriceToConfigurationItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "sales",
                table: "Brands",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "sales",
                table: "Interiors",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "sales",
                table: "Gearbox",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "sales",
                table: "EquipmentVersion",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "sales",
                table: "Engine",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "sales",
                table: "Colors",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "sales",
                table: "CarModel",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "sales",
                table: "CarClass",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "sales",
                table: "AdditionalEquipment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.ExecuteSqlEmbeddedResourceScript<AddPriceToConfigurationItems>(MigrationType.Up);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                schema: "sales",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "sales",
                table: "Interiors");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "sales",
                table: "Gearbox");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "sales",
                table: "EquipmentVersion");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "sales",
                table: "Engine");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "sales",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "sales",
                table: "CarModel");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "sales",
                table: "CarClass");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "sales",
                table: "AdditionalEquipment");
        }
    }
}
