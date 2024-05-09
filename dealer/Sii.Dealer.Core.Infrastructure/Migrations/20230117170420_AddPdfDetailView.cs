﻿using Microsoft.EntityFrameworkCore.Migrations;
using Sii.Dealer.Core.Infrastructure.Data;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    public partial class AddPdfDetailView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW sales.PdfDetailView AS SELECT orders.Id, orders.Customer_FirstName AS CustomerFirstName, orders.Customer_LastName AS CustomerLastName, orders.Customer_Email AS CustomerEmail,
                orders.Customer_Phone AS CustomerPhone, orders.CreationDate, orders.Price, orders.Price - orders.Price AS Discount, orders.Status, orders.AgreementIsSigned AS AgreementSigned, orders.AgreementSignedDate AS AgreementSignedDate, orders.PlannedDeliveryDate AS PlannedDeliveryDate, 
				orders.CarVin AS CarVin, brand.Name AS Brand, class.Name AS Class, model.Name AS Model, color.Name AS Color, engine.Name AS Engine, engine.Type AS EngineType,
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
			migrationBuilder.Sql($"DROP VIEW {SalesDbContext.SCHEMA_NAME}.PdfDetailView");
		}
    }
}
