using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiiCarOrder.Factory.Infracstructure.Migrations
{
    public partial class AddDeliveryDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                schema: "factory",
                table: "CarConfiguration",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                schema: "factory",
                table: "CarConfiguration");
        }
    }
}
