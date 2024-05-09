using Microsoft.EntityFrameworkCore.Migrations;
using Sii.Dealer.SharedKernel.Migrations;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    public partial class ChangeGearboxTypeToEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.ExecuteSqlEmbeddedResourceScript<ChangeGearboxTypeToEnum>(MigrationType.Up);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                schema: "sales",
                table: "Gearbox",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "sales",
                table: "Gearbox",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.ExecuteSqlEmbeddedResourceScript<ChangeGearboxTypeToEnum>(MigrationType.Down);
        }
    }
}
