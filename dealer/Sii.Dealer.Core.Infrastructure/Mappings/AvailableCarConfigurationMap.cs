using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sii.Dealer.Core.Domain.Entities.CarConfigurationEntities;

namespace Sii.Dealer.Core.Infrastructure.Mappings
{
    public class AvailableCarConfigurationMap : IEntityTypeConfiguration<AvailableCarConfiguration>
    {
        public void Configure(EntityTypeBuilder<AvailableCarConfiguration> builder)
        {
            builder.ToTable("AvailableConfigurations");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Color).WithMany().HasForeignKey(x => x.ColorCode).IsRequired();
            builder.HasOne(x => x.Interior).WithMany().HasForeignKey(x => x.InteriorCode).IsRequired();
            builder.HasOne(x => x.Brand).WithMany().HasForeignKey(x => x.BrandCode).IsRequired();
            builder.HasOne(x => x.EquipmentVersion).WithMany().HasForeignKey(x => x.EquipmentVersionCode).IsRequired();
            builder.HasOne(x => x.Model).WithMany().HasForeignKey(x => x.ModelCode).IsRequired();
            builder.HasOne(x => x.Class).WithMany().HasForeignKey(x => x.ClassCode).IsRequired();
            builder.HasOne(x => x.Engine).WithMany().HasForeignKey(x => x.EngineCode).IsRequired();
            builder.HasOne(x => x.Gearbox).WithMany().HasForeignKey(x => x.GearboxCode).IsRequired();
        }
    }
}
