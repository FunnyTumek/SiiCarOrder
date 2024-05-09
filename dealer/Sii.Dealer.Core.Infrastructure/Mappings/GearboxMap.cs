using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sii.Dealer.Core.Domain.Entities;

namespace Sii.Dealer.Core.Infrastructure.Mappings
{
    internal class GearboxMap : IEntityTypeConfiguration<Gearbox>
    {
        public void Configure(EntityTypeBuilder<Gearbox> builder)
        {
            builder.ToTable("Gearbox");

            builder.HasKey(x => x.Code);
            builder.Property(x => x.GearsCount).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Availability).HasDefaultValue(true);
        }
    }
}
