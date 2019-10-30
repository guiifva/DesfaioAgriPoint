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

            builder.Property(x => x.PurchaseDay)
                .IsRequired();

            builder.Property(x => x.PlanRenewalDate)
                .IsRequired();

            //Relations
            builder.HasOne(x => x.User)
                .WithMany(x => x.Order)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.CreditCard)
                .WithMany(x => x.Order)
                .HasForeignKey(x => x.CreditCardId);

            builder.HasOne(x => x.SubscriptionPlan)
                .WithMany(x => x.Order)
                .HasForeignKey(x => x.SubscriptionPlanId);

        }
    }
}
