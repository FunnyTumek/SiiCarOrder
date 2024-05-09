using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sales");

            migrationBuilder.CreateTable(
                name: "AdditionalEquipment",
                schema: "sales",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalEquipment", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "sales",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CarClass",
                schema: "sales",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarClass", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CarModel",
                schema: "sales",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModel", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                schema: "sales",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Code);
                });

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

            migrationBuilder.CreateTable(
                name: "EquipmentVersion",
                schema: "sales",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentVersion", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Gearbox",
                schema: "sales",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GearsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gearbox", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Interiors",
                schema: "sales",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interiors", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OriginalPrice = table.Column<decimal>(type: "money", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engine",
                schema: "sales",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Engine_EngineType_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "sales",
                        principalTable: "EngineType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderComments",
                schema: "sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderComments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "sales",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarConfiguration",
                schema: "sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BrandCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModelCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EquipmentVersionCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarClassCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EngineCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GearboxCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InteriorCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarConfiguration_Brands_BrandCode",
                        column: x => x.BrandCode,
                        principalSchema: "sales",
                        principalTable: "Brands",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarConfiguration_CarClass_CarClassCode",
                        column: x => x.CarClassCode,
                        principalSchema: "sales",
                        principalTable: "CarClass",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarConfiguration_CarModel_ModelCode",
                        column: x => x.ModelCode,
                        principalSchema: "sales",
                        principalTable: "CarModel",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarConfiguration_Colors_ColorCode",
                        column: x => x.ColorCode,
                        principalSchema: "sales",
                        principalTable: "Colors",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarConfiguration_Engine_EngineCode",
                        column: x => x.EngineCode,
                        principalSchema: "sales",
                        principalTable: "Engine",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarConfiguration_EquipmentVersion_EquipmentVersionCode",
                        column: x => x.EquipmentVersionCode,
                        principalSchema: "sales",
                        principalTable: "EquipmentVersion",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarConfiguration_Gearbox_GearboxCode",
                        column: x => x.GearboxCode,
                        principalSchema: "sales",
                        principalTable: "Gearbox",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarConfiguration_Interiors_InteriorCode",
                        column: x => x.InteriorCode,
                        principalSchema: "sales",
                        principalTable: "Interiors",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarConfiguration_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "sales",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalEquipmentSet",
                schema: "sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarConfigurationId = table.Column<int>(type: "int", nullable: false),
                    AdditionalEquipmentCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalEquipmentSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalEquipmentSet_AdditionalEquipment_AdditionalEquipmentCode",
                        column: x => x.AdditionalEquipmentCode,
                        principalSchema: "sales",
                        principalTable: "AdditionalEquipment",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_AdditionalEquipmentSet_CarConfiguration_CarConfigurationId",
                        column: x => x.CarConfigurationId,
                        principalSchema: "sales",
                        principalTable: "CarConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalEquipmentSet_AdditionalEquipmentCode",
                schema: "sales",
                table: "AdditionalEquipmentSet",
                column: "AdditionalEquipmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalEquipmentSet_CarConfigurationId",
                schema: "sales",
                table: "AdditionalEquipmentSet",
                column: "CarConfigurationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarConfiguration_BrandCode",
                schema: "sales",
                table: "CarConfiguration",
                column: "BrandCode");

            migrationBuilder.CreateIndex(
                name: "IX_CarConfiguration_CarClassCode",
                schema: "sales",
                table: "CarConfiguration",
                column: "CarClassCode");

            migrationBuilder.CreateIndex(
                name: "IX_CarConfiguration_ColorCode",
                schema: "sales",
                table: "CarConfiguration",
                column: "ColorCode");

            migrationBuilder.CreateIndex(
                name: "IX_CarConfiguration_EngineCode",
                schema: "sales",
                table: "CarConfiguration",
                column: "EngineCode");

            migrationBuilder.CreateIndex(
                name: "IX_CarConfiguration_EquipmentVersionCode",
                schema: "sales",
                table: "CarConfiguration",
                column: "EquipmentVersionCode");

            migrationBuilder.CreateIndex(
                name: "IX_CarConfiguration_GearboxCode",
                schema: "sales",
                table: "CarConfiguration",
                column: "GearboxCode");

            migrationBuilder.CreateIndex(
                name: "IX_CarConfiguration_InteriorCode",
                schema: "sales",
                table: "CarConfiguration",
                column: "InteriorCode");

            migrationBuilder.CreateIndex(
                name: "IX_CarConfiguration_ModelCode",
                schema: "sales",
                table: "CarConfiguration",
                column: "ModelCode");

            migrationBuilder.CreateIndex(
                name: "IX_CarConfiguration_OrderId",
                schema: "sales",
                table: "CarConfiguration",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Engine_TypeId",
                schema: "sales",
                table: "Engine",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderComments_OrderId",
                schema: "sales",
                table: "OrderComments",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalEquipmentSet",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "OrderComments",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "AdditionalEquipment",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "CarConfiguration",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "Brands",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "CarClass",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "CarModel",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "Colors",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "Engine",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "EquipmentVersion",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "Gearbox",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "Interiors",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "EngineType",
                schema: "sales");
        }
    }
}
