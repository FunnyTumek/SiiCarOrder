using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiiCarOrder.Factory.Infracstructure.Migrations
{
    public partial class AddProductionStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "factory",
                table: "CarConfiguration",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "factory",
                table: "CarConfiguration");
        }
    }
}
