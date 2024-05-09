using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sii.Dealer.Core.Domain.Entities;

namespace Sii.Dealer.Core.Infrastructure.Mappings
{
    internal class OrderCommentMap : IEntityTypeConfiguration<OrderComment>
    {
        public void Configure(EntityTypeBuilder<OrderComment> builder)
        {
            builder.ToTable("OrderComments");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.Comment).IsRequired();
        }
    }
}
