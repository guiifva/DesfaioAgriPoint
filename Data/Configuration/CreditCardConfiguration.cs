using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.ToTable("CreditCards");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CardholderName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.CreditCardNumber)
                .HasMaxLength(16)
                .IsRequired();
                
            builder.Property(x => x.Valid)
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(x => x.CVV)
                .HasMaxLength(3)
                .IsRequired();


        }
    }
}
