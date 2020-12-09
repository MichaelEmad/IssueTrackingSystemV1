using IssueTracking.Domain.Entities.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IssueTracking.Infra.Persistence.Configuration
{
    class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(project => project.Name).IsRequired();
            builder.Property(project => project.Key).IsRequired().HasMaxLength(4);
            builder.HasIndex(project => project.Key).IsUnique();
            builder.HasOne(project => project.Owner);
        }
    }
}
