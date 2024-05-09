using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiiCarOrder.Factory.Infracstructure.Migrations
{
    public partial class AddCarConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "factory");

            migrationBuilder.CreateTable(
                name: "CarConfiguration",
                schema: "factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentVersionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GearboxCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InteriorCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarConfiguration", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarConfiguration",
                schema: "factory");
        }
    }
}
