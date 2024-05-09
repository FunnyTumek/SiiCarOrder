using Microsoft.EntityFrameworkCore.Migrations;
using Sii.Dealer.Core.Infrastructure.Data;
using Sii.Dealer.SharedKernel.Migrations;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    public partial class OrderListViewAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.ExecuteSqlEmbeddedResourceScript<OrderListViewAdded>(MigrationType.Up);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DROP VIEW {SalesDbContext.SCHEMA_NAME}.OrderListView");
        }
    }
}
