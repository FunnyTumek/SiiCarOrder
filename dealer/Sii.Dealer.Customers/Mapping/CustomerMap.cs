﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sii.Dealer.Customers.Entities;

namespace Sii.Dealer.Customers.Mapping
{
    internal class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.IdentityNo);
            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique(true);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.City);
            builder.Property(x => x.Street);
            builder.Property(x => x.Number).HasMaxLength(10);
            builder.Property(x => x.Phone).HasMaxLength(20);
        }
    }
}
