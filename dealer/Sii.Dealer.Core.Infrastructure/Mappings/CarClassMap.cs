using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sii.Dealer.Core.Domain.Entities;

namespace Sii.Dealer.Core.Infrastructure.Mappings
{
    public class CarClassMap : IEntityTypeConfiguration<CarClass>
    {
        public void Configure(EntityTypeBuilder<CarClass> builder)
        {
            builder.ToTable("CarClass");

            builder.HasKey(x => x.Code);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Availability).HasDefaultValue(true);
        }
    }
}
