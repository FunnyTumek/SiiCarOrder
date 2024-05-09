using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiiCarOrder.Factory.Domain.Entities;

namespace SiiCarOrder.Factory.Infrastructure.Persistance
{
    public class OrderedProductionMap : IEntityTypeConfiguration<OrderedProduction>
    {
        public void Configure(EntityTypeBuilder<OrderedProduction> builder)
        {
            builder.ToTable("OrderedProductions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.BrandCode).IsRequired();
            builder.Property(x => x.ModelCode).IsRequired();
            builder.Property(x => x.EquipmentVersionCode).IsRequired();
            builder.Property(x => x.ClassCode).IsRequired();
            builder.Property(x => x.EngineCode).IsRequired();
            builder.Property(x => x.GearboxCode).IsRequired();
            builder.Property(x => x.ColorCode).IsRequired();
            builder.Property(x => x.InteriorCode).IsRequired();
            builder.Property(x => x.DeliveryDate).IsRequired();
            builder.Property(x => x.CreateDate).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.OrderId).IsRequired();
        }
    }
}
