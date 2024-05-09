using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sii.Dealer.Core.Domain.Entities;

namespace Sii.Dealer.Core.Infrastructure.Mappings
{
    public class EngineMap : IEntityTypeConfiguration<Engine>
    {
        public void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder.ToTable("Engine");

            builder.HasKey(x => x.Code);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Capacity).IsRequired();
            builder.Property(x => x.Power).IsRequired();
            builder.Property(x=>x.Type).IsRequired();
            builder.Property(x => x.Availability).HasDefaultValue(true);
        }
    }
}
