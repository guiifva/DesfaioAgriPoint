using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.State)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Street)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.PlaceNumber)
                .IsRequired();

            builder.Property(x => x.Complement)
                .HasMaxLength(100);

            builder.HasOne(x => x.User)
                .WithOne(x => x.Address)
                .HasForeignKey<Address>(x => x.UserId);
                
        }
    }
}
