using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiiCarOrder.Factory.Domain.Entities;

namespace SiiCarOrder.Factory.Infrastructure.Persistance
{
    public class OrderedProductionProgressStateMap : IEntityTypeConfiguration<OrderedProductionProgressState>
    {
        public void Configure(EntityTypeBuilder<OrderedProductionProgressState> builder)
        {
            builder.ToTable("OrderedProductionsProgressStates");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ProductionId).IsRequired();
            builder.Property(x => x.State).IsRequired();
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Information).IsRequired(false);
        }
    }
}
