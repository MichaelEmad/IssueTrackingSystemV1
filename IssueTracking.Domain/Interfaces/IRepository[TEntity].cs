using System;


namespace IssueTracking.Domain.Interfaces
{
    public interface IRepository<TEntity>
        : IRepository<TEntity, Guid>
        where TEntity : IAggregateRoot, IEntity
    {
    }
}
