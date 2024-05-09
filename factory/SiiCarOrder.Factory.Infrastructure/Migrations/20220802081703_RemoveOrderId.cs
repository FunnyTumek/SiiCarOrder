using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiiCarOrder.Factory.Infracstructure.Migrations
{
    public partial class RemoveOrderId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "factory",
                table: "CarConfiguration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                schema: "factory",
                table: "CarConfiguration",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
