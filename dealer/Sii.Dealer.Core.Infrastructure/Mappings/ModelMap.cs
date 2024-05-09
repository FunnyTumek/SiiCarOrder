using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sii.Dealer.Core.Domain.Entities;

namespace Sii.Dealer.Core.Infrastructure.Mappings
{
    public class ModelMap : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("CarModel");

            builder.HasKey(x => x.Code);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Availability).HasDefaultValue(true);
        }
    }
}
