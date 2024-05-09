using Sii.Dealer.Core.Domain.Entities;
using System;

namespace Sii.Dealer.Core.Domain.Repositories
{
    public interface IOrdersRepository
    {
        Order Get(int id);
        void Add(Order order);
    }
}
