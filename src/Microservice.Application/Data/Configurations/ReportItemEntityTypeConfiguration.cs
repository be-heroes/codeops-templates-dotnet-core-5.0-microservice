using Microservice.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Microservice.Infrastructure.EntityFramework.Configurations
{
    public class ReportItemEntityTypeConfiguration : IEntityTypeConfiguration<ReportRoot>
    {
        public void Configure(EntityTypeBuilder<ReportRoot> builder)
        {
            builder.Ignore(v => v.DomainEvents);
            builder.Property(v => v.Id).IsRequired();
            builder.Property(v => v.Created);
            builder.HasKey(v => v.Id);
            builder.ToTable("ReportItem");

            builder.OwnsMany(
            p => p.CostItems, a =>
            {
                a.WithOwner().HasForeignKey("OwnerId");
                a.Property<Guid>("Id");
                a.HasKey("Id");
            });
        }
    }
}