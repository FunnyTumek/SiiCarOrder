using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sii.Dealer.Core.Domain.Entities;

namespace Sii.Dealer.Core.Infrastructure.Mappings
{
    public class ColorMap : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Colors");

            builder.HasKey(x => x.Code);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Availability).HasDefaultValue(true);
        }
    }
}
