using IssueTracking.Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IssueTracking.Infra.Persistence.Configuration
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(user => user.ProjectsOwner)
                .WithOne(project => project.Owner);
            builder.HasMany(user => user.Projects)
                .WithMany(project => project.Participants);

        }
    }
}
