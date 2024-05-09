using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiiCarOrder.Factory.Infracstructure.Migrations
{
    public partial class ChangeStartedDateColumnNameInOrderdProductionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartedDate",
                schema: "factory",
                table: "OrderedProductions",
                newName: "CreateDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                schema: "factory",
                table: "OrderedProductions",
                newName: "StartedDate");
        }
    }
}
