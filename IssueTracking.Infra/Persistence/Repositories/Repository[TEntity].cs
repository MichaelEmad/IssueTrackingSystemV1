using System;
using IssueTracking.Domain.Interfaces;

namespace IssueTracking.Infra.Persistence.Repositories
{
    public class Repository<TEnity> : Repository<TEnity, Guid>, IRepository<TEnity>
        where TEnity : class, IAggregateRoot, IEntity
    {
        public Repository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}