using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sii.Dealer.Core.Domain.Entities;

namespace Sii.Dealer.Core.Infrastructure.Mappings
{
    internal class EquipmentVersionMap : IEntityTypeConfiguration<EquipmentVersion>
    {
        public void Configure(EntityTypeBuilder<EquipmentVersion> builder)
        {
            builder.ToTable("EquipmentVersion");

            builder.HasKey(x => x.Code);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Availability).HasDefaultValue(true);
        }
    }
}
