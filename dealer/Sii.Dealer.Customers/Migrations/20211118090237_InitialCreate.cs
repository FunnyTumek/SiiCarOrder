using Microsoft.EntityFrameworkCore.Migrations;
using Sii.Dealer.SharedKernel.Enums;

namespace Sii.Dealer.Customers.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "customers");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IdentityNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(table: "Customers",
                columns: new[] { "Type", "IdentityNo", "FirstName", "LastName", "City", "Street", "Number", "Phone" },
                values: new object[] { (int)CustomerType.Standard, "123456", "Johnny", "Bravo", "Lublin", "Szeligowskiego", "6B", "123-456-789" },
                schema: "customers");

            migrationBuilder.InsertData(table: "Customers",
                columns: new[] { "Type", "IdentityNo", "FirstName", "LastName", "City", "Street", "Number", "Phone" },
                values: new object[] { (int)CustomerType.Business, "111222", "Denis", "Rodman", "LA", "1st", "222", "000-111-222" },
                schema: "customers");

            migrationBuilder.InsertData(table: "Customers",
                columns: new[] { "Type", "IdentityNo", "FirstName", "LastName", "City", "Street", "Number", "Phone" },
                values: new object[] { (int)CustomerType.Vip, "111111", "Chuck", "Norris", "W-wa", "Nowy Świat", "1", "111-111-111" },
                schema: "customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers",
                schema: "customers");
        }
    }
}
