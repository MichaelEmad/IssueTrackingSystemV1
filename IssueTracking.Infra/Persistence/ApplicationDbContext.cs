using System.Reflection;
using IssueTracking.Domain.Entities;
using IssueTracking.Domain.Entities.IssueAggregate;
using IssueTracking.Domain.Entities.ProjectAggregate;
using IssueTracking.Domain.Entities.UserAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IssueTracking.Infra.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Project> Project { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<ParticipantsProjects> ParticipantsProject { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

       
    }
}
