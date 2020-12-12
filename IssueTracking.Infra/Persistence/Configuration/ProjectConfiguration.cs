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
            builder.Property(project => project.SerialNumber).UseIdentityColumn();
            builder.HasMany(project => project.Participants)
                .WithMany(user => user.Projects);
            builder.HasMany(project => project.Issues)
                .WithOne(issue => issue.Project);
        }
    }
}
