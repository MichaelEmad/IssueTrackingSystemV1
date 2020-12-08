using System;

namespace IssueTracking.Domain.Interfaces
{
    public abstract class Entity : Entity<Guid>, IEntity
    {
    }
}
