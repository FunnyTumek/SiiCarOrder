using Microsoft.EntityFrameworkCore.Migrations;
using Sii.Dealer.SharedKernel.Migrations;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    public partial class RemovedEngineType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engine_EngineType_TypeId",
                schema: "sales",
                table: "Engine");

            migrationBuilder.DropTable(
                name: "EngineType",
                schema: "sales");

            migrationBuilder.DropIndex(
                name: "IX_Engine_TypeId",
                schema: "sales",
                table: "Engine");

            migrationBuilder.DropColumn(
                name: "TypeId",
                schema: "sales",
                table: "Engine");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "sales",
                table: "Engine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            

            migrationBuilder.ExecuteSqlEmbeddedResourceScript<RemovedEngineType>(MigrationType.Up);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                schema: "sales",
                table: "Engine");

            migrationBuilder.AddColumn<string>(
                name: "TypeId",
                schema: "sales",
                table: "Engine",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EngineType",
                schema: "sales",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Engine_TypeId",
                schema: "sales",
                table: "Engine",
                column: "TypeId");

            migrationBuilder.ExecuteSqlEmbeddedResourceScript<RemovedEngineType>(MigrationType.Down);

            migrationBuilder.AddForeignKey(
                name: "FK_Engine_EngineType_TypeId",
                schema: "sales",
                table: "Engine",
                column: "TypeId",
                principalSchema: "sales",
                principalTable: "EngineType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
   
        }
    }
}
