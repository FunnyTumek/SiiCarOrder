using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sii.Dealer.Core.Domain.Entities;

namespace Sii.Dealer.Core.Infrastructure.Mappings
{
    public class AdditionalEquipmentsSetMap : IEntityTypeConfiguration<AdditionalEquipmentSet>
    {
        public void Configure(EntityTypeBuilder<AdditionalEquipmentSet> builder)
        {
            builder.ToTable("AdditionalEquipmentSet");

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.AdditionalEquipment).WithMany(y => y.AdditionalEquipmentSet);
        }
    }
}
