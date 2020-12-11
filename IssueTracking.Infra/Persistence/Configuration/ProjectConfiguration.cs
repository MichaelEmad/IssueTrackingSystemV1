using IssueTracking.Domain.Entities.ProjectAggregate;
using IssueTracking.Domain.Entities.UserAggregate;
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
            builder.HasOne(project => project.Owner)
                .WithOne(user=>user.Project)
                .HasForeignKey<User>(user=>user.Id)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(project => project.SerialNumber).UseIdentityColumn();
            builder.HasMany(project => project.ParticipantsProjects)
                .WithMany(user => user.ParticipantsProjects);
            builder.HasMany(project => project.Issues)
                .WithOne(issue => issue.Project);

        }
    }
}
