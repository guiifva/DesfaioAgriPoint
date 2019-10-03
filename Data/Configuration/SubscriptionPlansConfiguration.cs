using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class SubscriptionPlansConfiguration : IEntityTypeConfiguration<SubscriptionPlans>
    {
        public void Configure(EntityTypeBuilder<SubscriptionPlans> builder)
        {
            builder.ToTable("SubscriptionsPlans");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.)
                .IsUnique();

            builder.Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            //Relations
            builder.HasOne(x => x.Address)
                .WithOne(x => x.User)
                .HasForeignKey<User>(x => x.AdressId);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.CompanyId);
                 
        }
    }
}
