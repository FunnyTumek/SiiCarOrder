using Sii.Dealer.Core.Base.UnitOfWork;
using Sii.Dealer.Core.Domain;
using Sii.Dealer.Core.Infrastructure.Data;

namespace Sii.Dealer.Core.Infrastructure
{
    public class SalesUnitOfWork : EntityFrameworkUnitOfWork<SalesDbContext>, ISalesUnitOfWork
    {
        public SalesUnitOfWork(SalesDbContext context) : base(context)
        {
        }
    }
}
