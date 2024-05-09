using Microsoft.EntityFrameworkCore.Migrations;
using Sii.Dealer.Core.Infrastructure.Data;
using Sii.Dealer.SharedKernel.Migrations;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    public partial class OrderDetailListViewAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.ExecuteSqlEmbeddedResourceScript<OrderDetailListViewAdded>(MigrationType.Up);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DROP VIEW {SalesDbContext.SCHEMA_NAME}.OrderDetailListView");
        }
    }
}
