using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Total)
                .IsRequired();

            builder.Property(x => x.CreditCardNumber)
                .HasMaxLength(16)
                .IsRequired();

            //Relations
            builder.HasOne(x => x.User)
                .WithOne(x => x.Order);
                
        }
    }
}
