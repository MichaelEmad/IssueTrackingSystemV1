using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using JetBrains.Annotations;

namespace IssueTracking.Domain.Interfaces
{
    public interface IRepository<TEntity, TKey>
        where TEntity : IAggregateRoot, IEntity<TKey>
    {
        Task<IReadOnlyCollection<TEntity>> GetAllAsync([NotNull] ISpecification<TEntity> specification);

        Task<TEntity> GetByIdAsync(TKey id);

        Task<TEntity> GetSingleOrDefaultAsync([NotNull] ISpecification<TEntity> specification);

        Task<TEntity> GetFirstOrDefaultAsync([NotNull] ISpecification<TEntity> specification);

        Task<int> CountAsync([NotNull] ISpecification<TEntity> specification);

        Task<bool> AnyAsync([NotNull] ISpecification<TEntity> specification);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entity);

        void Delete(TEntity entity);

        void Delete(TKey id);

        void DeleteRange(IEnumerable<TKey> ids);

        void Delete([NotNull] ISpecification<TEntity> specification);
    }
}
