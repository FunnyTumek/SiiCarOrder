using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sii.Dealer.Customers.Migrations
{
    public partial class AddStringIdentityNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityNo",
                schema: "customers",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(table: "Customers", keyColumn: "Email", keyValue: "Johnny@Bravo.com", column: "IdentityNo", value: "111111", schema: "customers");
            migrationBuilder.UpdateData(table: "Customers", keyColumn: "Email", keyValue: "Denis@Rodman.com", column: "IdentityNo", value: "222222", schema: "customers");
            migrationBuilder.UpdateData(table: "Customers", keyColumn: "Email", keyValue: "Chuck@Norris.com", column: "IdentityNo", value: "333333", schema: "customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityNo",
                schema: "customers",
                table: "Customers");
        }
    }
}
