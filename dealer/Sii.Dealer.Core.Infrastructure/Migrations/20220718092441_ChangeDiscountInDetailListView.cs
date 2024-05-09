using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    public partial class ChangeDiscountInDetailListView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                schema: "sales",
                table: "Payments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
            migrationBuilder.Sql(@"ALTER VIEW [sales].[OrderDetailListView] AS
                SELECT orders.Id, orders.Customer_FirstName AS CustomerFirstName, orders.Customer_LastName AS CustomerLastName, orders.Customer_Email AS CustomerEmail,
                orders.Customer_Phone AS CustomerPhone, orders.CreationDate, orders.Price, orders.Price - orders.Price AS Discount, orders.Status,
                brand.Name AS Brand, class.Name AS Class, model.Name AS Model, color.Name AS Color, engine.Name AS Engine, engine.Type AS EngineType,
                engine.Power AS EnginePower, engine.Capacity AS EngineCapacity, equipment.Name AS EquipmentVersion, gear.Type AS GearboxType, gear.GearsCount
                AS GearboxCount, interiors.Name AS Interior
                FROM sales.Orders orders
                INNER JOIN sales.CarConfiguration conf
                ON orders.Id = conf.OrderId
                INNER JOIN sales.Brands brand
                ON conf.BrandCode = brand.Code
                INNER JOIN sales.CarClass class
                ON conf.CarClassCode = class.Code
                INNER JOIN sales.CarModel model
                ON conf.ModelCode = model.Code
                INNER JOIN sales.Colors color
                ON conf.ColorCode = color.Code
                INNER JOIN sales.Engine engine
                ON conf.EngineCode = engine.Code
                INNER JOIN sales.EquipmentVersion equipment
                ON conf.EquipmentVersionCode = equipment.Code
                INNER JOIN sales.Gearbox gear
                ON conf.GearboxCode = gear.Code
                INNER JOIN sales.Interiors interiors
                ON conf.InteriorCode = interiors.Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                schema: "sales",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
            migrationBuilder.Sql(@"ALTER VIEW [sales].[OrderDetailListView] AS
                SELECT orders.Id, orders.Customer_FirstName AS CustomerFirstName, orders.Customer_LastName AS CustomerLastName, orders.Customer_Email AS CustomerEmail,
                orders.Customer_Phone AS CustomerPhone, orders.CreationDate, orders.Price, orders.OriginalPrice - orders.Price AS Discount, orders.Status,
                brand.Name AS Brand, class.Name AS Class, model.Name AS Model, color.Name AS Color, engine.Name AS Engine, engine.Type AS EngineType,
                engine.Power AS EnginePower, engine.Capacity AS EngineCapacity, equipment.Name AS EquipmentVersion, gear.Type AS GearboxType, gear.GearsCount
                AS GearboxCount, interiors.Name AS Interior
                FROM sales.Orders orders
                INNER JOIN sales.CarConfiguration conf
                ON orders.Id = conf.OrderId
                INNER JOIN sales.Brands brand
                ON conf.BrandCode = brand.Code
                INNER JOIN sales.CarClass class
                ON conf.CarClassCode = class.Code
                INNER JOIN sales.CarModel model
                ON conf.ModelCode = model.Code
                INNER JOIN sales.Colors color
                ON conf.ColorCode = color.Code
                INNER JOIN sales.Engine engine
                ON conf.EngineCode = engine.Code
                INNER JOIN sales.EquipmentVersion equipment
                ON conf.EquipmentVersionCode = equipment.Code
                INNER JOIN sales.Gearbox gear
                ON conf.GearboxCode = gear.Code
                INNER JOIN sales.Interiors interiors
                ON conf.InteriorCode = interiors.Code");
        }
    }
}
