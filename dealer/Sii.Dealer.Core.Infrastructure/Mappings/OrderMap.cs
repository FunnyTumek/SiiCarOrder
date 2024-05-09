using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.Core.Infrastructure.Data;

namespace Sii.Dealer.Core.Infrastructure.Mappings
{
    internal class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.CreationDate).IsRequired();
            builder.Property(o => o.Price).IsRequired().HasColumnType(SalesDbContext.DB_MONEY_TYPE);
            builder.Property(o => o.AgreementIsSigned).IsRequired();
            builder.Ignore(o => o.Discount);
            builder.Property(o => o.Status).IsRequired();
            builder.Property(o => o.PlannedDeliveryDate);
            builder.Property(o => o.ReleaseDate);
            builder.Property(o => o.AgreementSignedDate);
            builder.Property(o => o.CarVin);
            builder.Property(o => o.ProductionStartDate);
            builder.OwnsOne(x => x.Customer);
            builder.HasMany(x => x.Comments).WithOne(x => x.Order).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Payments).WithOne(x => x.Order).OnDelete(DeleteBehavior.Cascade);
            builder.Metadata.FindNavigation(nameof(Order.Comments)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasOne(x => x.Configuration).WithOne(y => y.Order).HasForeignKey<CarConfiguration>(c => c.OrderId);
        }
    }
}
