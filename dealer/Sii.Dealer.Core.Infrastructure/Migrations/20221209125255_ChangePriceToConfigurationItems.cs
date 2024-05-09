using Microsoft.EntityFrameworkCore.Migrations;
using Sii.Dealer.SharedKernel.Migrations;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    public partial class ChangePriceToConfigurationItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.ExecuteSqlEmbeddedResourceScript<ChangePriceToConfigurationItems>(MigrationType.Up);
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.ExecuteSqlEmbeddedResourceScript<AddPriceToConfigurationItems>(MigrationType.Up);
		}
    }
}
