using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sii.Dealer.SharedKernel.Enums;
using Sii.Dealer.SharedKernel.Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Infrastructure.Mappings
{
    public class OrderListViewModelMap : IEntityTypeConfiguration<OrderListViewModel>
    {
        public void Configure(EntityTypeBuilder<OrderListViewModel> builder)
        {
            builder.ToView("OrderListView");
            builder.HasNoKey();
        }
    }
}
