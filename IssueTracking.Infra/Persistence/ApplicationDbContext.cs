using System;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using IssueTracking.Domain.Entities.IssueAggregate;
using IssueTracking.Domain.Entities.ProjectAggregate;
using IssueTracking.Domain.Entities.UserAggregate;
using IssueTracking.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IssueTracking.Infra.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IUnitOfWork
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DbSet<Project> Project { get; set; }
        public DbSet<Issue> Issue { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public async Task SaveChangesAsync()
        {
            foreach (EntityEntry<Entity> entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _httpContextAccessor.HttpContext.User
                            .FindFirst(ClaimTypes.NameIdentifier).Value;
                        entry.Entity.CreationDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = _httpContextAccessor.HttpContext.User
                            .FindFirst(ClaimTypes.NameIdentifier).Value;
                        entry.Entity.ModificationDate = DateTime.Now;
                        break;
                }
            }
            await base.SaveChangesAsync();
        }
    }
}
