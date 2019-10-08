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

            builder.Property(x => x.PlanName)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Value)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(255)
                .IsRequired();
                 
        }
    }
}
