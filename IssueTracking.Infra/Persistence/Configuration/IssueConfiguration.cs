using System;
using System.ComponentModel.Design;
using IssueTracking.Domain.Entities.IssueAggregate;
using IssueTracking.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IssueTracking.Infra.Persistence.Configuration
{
    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.Property(issue => issue.Title).IsRequired();
            builder.Property(issue => issue.Type).HasConversion<string>();
            builder.Property(issue => issue.Status).HasDefaultValue(IssueStatus.Todo).HasConversion<string>();
            builder.Property(issue => issue.Description).HasMaxLength(Int32.MaxValue);
            builder.HasOne(issue => issue.Reporter);

        }
    }
}
