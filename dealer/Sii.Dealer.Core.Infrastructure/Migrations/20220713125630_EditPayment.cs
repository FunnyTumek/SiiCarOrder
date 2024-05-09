using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    public partial class EditPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Orders_OrderId",
                schema: "sales",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                schema: "sales",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "Payment",
                schema: "sales",
                newName: "Payments",
                newSchema: "sales");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_OrderId",
                schema: "sales",
                table: "Payments",
                newName: "IX_Payments_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                schema: "sales",
                table: "Payments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderId",
                schema: "sales",
                table: "Payments",
                column: "OrderId",
                principalSchema: "sales",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderId",
                schema: "sales",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                schema: "sales",
                table: "Payments");

            migrationBuilder.RenameTable(
                name: "Payments",
                schema: "sales",
                newName: "Payment",
                newSchema: "sales");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_OrderId",
                schema: "sales",
                table: "Payment",
                newName: "IX_Payment_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                schema: "sales",
                table: "Payment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Orders_OrderId",
                schema: "sales",
                table: "Payment",
                column: "OrderId",
                principalSchema: "sales",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
