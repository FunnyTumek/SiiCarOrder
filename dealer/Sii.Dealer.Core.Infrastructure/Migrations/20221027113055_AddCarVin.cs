using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    public partial class AddCarVin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarVin",
                schema: "sales",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarVin",
                schema: "sales",
                table: "Orders");
        }
    }
}
