using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sii.Dealer.Core.Base.Repositories;
using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.Core.Domain.Repositories;
using Sii.Dealer.Core.Infrastructure.Data;

namespace Sii.Dealer.Core.Infrastructure.Repositories
{
    public class OrdersRepository : AbstractRepository<Order, int, SalesDbContext>, IOrdersRepository
    {
        public OrdersRepository(SalesDbContext context) : base(context)
        {
        }

        public override Order Get(int id)
        {
            return Context.Orders
                .Include(x => x.Comments)
                .Include(x => x.Configuration.Brand)
                .Include(x => x.Configuration.CarClass)
                .Include(x => x.Configuration.Model)
                .Include(x => x.Configuration.Color)
                .Include(x => x.Configuration.Engine)
                .Include(x => x.Configuration.EquipmentVersion)
                .Include(x => x.Configuration.Gearbox)
                .Include(x => x.Configuration.Interior)
                .Include(x => x.Payments)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
