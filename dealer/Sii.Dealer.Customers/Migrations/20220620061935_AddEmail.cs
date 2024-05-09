using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sii.Dealer.Customers.Migrations
{
    public partial class AddEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "customers",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(table: "Customers", keyColumn: "IdentityNo", keyValue: "123456", column: "Email", value: "Johnny@Bravo.com", schema: "customers");
            migrationBuilder.UpdateData(table: "Customers", keyColumn: "IdentityNo", keyValue: "111222", column: "Email", value: "Denis@Rodman.com", schema: "customers");
            migrationBuilder.UpdateData(table: "Customers", keyColumn: "IdentityNo", keyValue: "111111", column: "Email", value: "Chuck@Norris.com", schema: "customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "customers",
                table: "Customers");
        }
    }
}
