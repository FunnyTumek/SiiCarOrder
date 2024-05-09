using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sii.Dealer.Customers.Migrations
{
    public partial class GuidCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(table: "Customers", keyColumn: "Email", keyValue: "Johnny@Bravo.com", column: "IdentityNo", value: Guid.NewGuid(), schema: "customers");
            migrationBuilder.UpdateData(table: "Customers", keyColumn: "Email", keyValue: "Denis@Rodman.com", column: "IdentityNo", value: Guid.NewGuid(), schema: "customers");
            migrationBuilder.UpdateData(table: "Customers", keyColumn: "Email", keyValue: "Chuck@Norris.com", column: "IdentityNo", value: Guid.NewGuid(), schema: "customers");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityNo",
                schema: "customers",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdentityNo",
                schema: "customers",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
