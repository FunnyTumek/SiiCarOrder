using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sii.Dealer.Core.Domain.Entities;

namespace Sii.Dealer.Core.Infrastructure.Mappings
{
    public class InteriorMap : IEntityTypeConfiguration<Interior>
    {
        public void Configure(EntityTypeBuilder<Interior> builder)
        {
            builder.ToTable("Interiors");

            builder.HasKey(x => x.Code);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Availability).HasDefaultValue(true);
        }
    }
}
