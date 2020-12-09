using System;
using System.Collections.Generic;
using System.Text;
using IssueTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IssueTracking.Infra.Persistence.Configuration
{
    class ParticipantsProjectConfigurations:IEntityTypeConfiguration<ParticipantsProjects>
    {
        public void Configure(EntityTypeBuilder<ParticipantsProjects> builder)
        {
            builder.HasOne(pp => pp.Projects)
                .WithMany(project => project.ParticipantsProjects)
                .HasForeignKey(x => x.ProjectId);
            builder.HasOne(pp => pp.Participants)
                .WithMany(user => user.ParticipantsProjects)
                .HasForeignKey(x => x.UserId);
        }
    }
}
