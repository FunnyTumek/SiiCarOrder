using Microsoft.EntityFrameworkCore.Migrations;
using Sii.Dealer.SharedKernel.Migrations;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    public partial class AddAvailableConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableConfigurations",
                schema: "sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModelCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EquipmentVersionCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClassCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EngineCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GearboxCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InteriorCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableConfigurations_Brands_BrandCode",
                        column: x => x.BrandCode,
                        principalSchema: "sales",
                        principalTable: "Brands",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableConfigurations_CarClass_ClassCode",
                        column: x => x.ClassCode,
                        principalSchema: "sales",
                        principalTable: "CarClass",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableConfigurations_CarModel_ModelCode",
                        column: x => x.ModelCode,
                        principalSchema: "sales",
                        principalTable: "CarModel",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableConfigurations_Colors_ColorCode",
                        column: x => x.ColorCode,
                        principalSchema: "sales",
                        principalTable: "Colors",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableConfigurations_Engine_EngineCode",
                        column: x => x.EngineCode,
                        principalSchema: "sales",
                        principalTable: "Engine",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableConfigurations_EquipmentVersion_EquipmentVersionCode",
                        column: x => x.EquipmentVersionCode,
                        principalSchema: "sales",
                        principalTable: "EquipmentVersion",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableConfigurations_Gearbox_GearboxCode",
                        column: x => x.GearboxCode,
                        principalSchema: "sales",
                        principalTable: "Gearbox",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableConfigurations_Interiors_InteriorCode",
                        column: x => x.InteriorCode,
                        principalSchema: "sales",
                        principalTable: "Interiors",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableConfigurationAdditionalEquipment",
                schema: "sales",
                columns: table => new
                {
                    AvailableConfigurationId = table.Column<int>(type: "int", nullable: false),
                    EquipmentCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableConfigurationAdditionalEquipment", x => new { x.AvailableConfigurationId, x.EquipmentCode });
                    table.ForeignKey(
                        name: "FK_AvailableConfigurationAdditionalEquipment_AdditionalEquipment_EquipmentCode",
                        column: x => x.EquipmentCode,
                        principalSchema: "sales",
                        principalTable: "AdditionalEquipment",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableConfigurationAdditionalEquipment_AvailableConfigurations_AvailableConfigurationId",
                        column: x => x.AvailableConfigurationId,
                        principalSchema: "sales",
                        principalTable: "AvailableConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableConfigurationAdditionalEquipment_EquipmentCode",
                schema: "sales",
                table: "AvailableConfigurationAdditionalEquipment",
                column: "EquipmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableConfigurations_BrandCode",
                schema: "sales",
                table: "AvailableConfigurations",
                column: "BrandCode");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableConfigurations_ClassCode",
                schema: "sales",
                table: "AvailableConfigurations",
                column: "ClassCode");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableConfigurations_ColorCode",
                schema: "sales",
                table: "AvailableConfigurations",
                column: "ColorCode");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableConfigurations_EngineCode",
                schema: "sales",
                table: "AvailableConfigurations",
                column: "EngineCode");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableConfigurations_EquipmentVersionCode",
                schema: "sales",
                table: "AvailableConfigurations",
                column: "EquipmentVersionCode");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableConfigurations_GearboxCode",
                schema: "sales",
                table: "AvailableConfigurations",
                column: "GearboxCode");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableConfigurations_InteriorCode",
                schema: "sales",
                table: "AvailableConfigurations",
                column: "InteriorCode");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableConfigurations_ModelCode",
                schema: "sales",
                table: "AvailableConfigurations",
                column: "ModelCode");

            migrationBuilder.ExecuteSqlEmbeddedResourceScript<AddAvailableConfigurations>(MigrationType.Up);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableConfigurationAdditionalEquipment",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "AvailableConfigurations",
                schema: "sales");
        }
    }
}
