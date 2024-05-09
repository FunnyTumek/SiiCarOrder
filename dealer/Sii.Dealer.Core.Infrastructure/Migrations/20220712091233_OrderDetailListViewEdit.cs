using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    public partial class OrderDetailListViewEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW [sales].[OrderDetailListView] AS
                SELECT orders.Id, orders.Customer_FirstName AS CustomerFirstName, orders.Customer_LastName AS CustomerLastName, orders.Customer_Email AS CustomerEmail, 
                orders.Customer_Phone AS CustomerPhone, orders.Price, orders.Status, brand.Name AS Brand, class.Name AS Class, model.Name AS Model, color.Name AS Color,
                engine.Name AS Engine, engine.Type AS EngineType, engine.Power AS EnginePower, engine.Capacity AS EngineCapacity, equipment.Name AS EquipmentVersion,
                gear.Type AS GearboxType, gear.GearsCount AS GearboxCount, interiors.Name AS Interior FROM sales.Orders orders
                INNER JOIN sales.CarConfiguration conf
                on orders.Id = conf.OrderId
                INNER JOIN sales.Brands brand
                on conf.BrandCode = brand.Code
                INNER JOIN sales.CarClass class
                on conf.CarClassCode = class.Code
                INNER JOIN sales.CarModel model
                on conf.ModelCode = model.Code
                INNER JOIN sales.Colors color
                on conf.ColorCode = color.Code
                INNER JOIN sales.Engine engine
                on conf.EngineCode = engine.Code
                INNER JOIN sales.EquipmentVersion equipment
                on conf.EquipmentVersionCode = equipment.Code
                INNER JOIN sales.Gearbox gear
                on conf.GearboxCode = gear.Code
                INNER JOIN sales.Interiors interiors
                on conf.InteriorCode = interiors.Code");
        }
    }
}
