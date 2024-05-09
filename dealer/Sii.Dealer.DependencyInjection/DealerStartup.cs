using Autofac;
using Microsoft.EntityFrameworkCore;
using Sii.Dealer.Core.Infrastructure.Data;
using Sii.Dealer.Customers;

namespace Sii.Dealer.DependencyInjection
{
    public class DealerStartup
    {
        public static void EnsureDatabaseStructure(ILifetimeScope scope)
        {
            using (var context = scope.Resolve<CustomersDbContext>())
            {
                context.Database.Migrate();
            }

            using (var context = scope.Resolve<SalesDbContext>())
            {
                context.Database.Migrate();
            }
        }
    }
}
