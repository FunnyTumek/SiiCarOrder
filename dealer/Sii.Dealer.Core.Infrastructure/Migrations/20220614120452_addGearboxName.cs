using Microsoft.EntityFrameworkCore.Migrations;
using Sii.Dealer.SharedKernel.Migrations;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    public partial class addGearboxName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "sales",
                table: "Gearbox",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.ExecuteSqlEmbeddedResourceScript<addGearboxName>(MigrationType.Up);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "sales",
                table: "Gearbox");
        }
    }
}
