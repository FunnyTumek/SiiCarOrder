using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sii.Dealer.Customers.Migrations
{
    public partial class DeleteIdentityNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityNo",
                schema: "customers",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdentityNo",
                schema: "customers",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
