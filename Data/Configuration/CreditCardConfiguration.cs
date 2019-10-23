﻿using Data.Models;
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

            builder.Property(x => x.Valid)
                .HasMaxLength(5);

            builder.Property(x => x.CreditCardNumber)
                .HasMaxLength(16)
                .IsRequired();

                
        }
    }
}
