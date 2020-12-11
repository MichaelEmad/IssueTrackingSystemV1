using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using IssueTracking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace IssueTracking.Infra.Persistence.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IAggregateRoot, Domain.Interfaces.IEntity<TKey>
    {
        protected ApplicationDbContext DbContext { get; }

        public Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;

        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(ISpecification<TEntity> specification)
        {
            var specificationResult = ApplySpecification(specification);
            return await specificationResult.ToListAsync();
        }

        public Task<TEntity> GetByIdAsync(TKey id)
        {
            return DbContext.Set<TEntity>().FindAsync(id).AsTask();
        }

        public async Task<TEntity> GetSingleOrDefaultAsync(ISpecification<TEntity> specification)
        {
            var specificationResult = ApplySpecification(specification);
            return await specificationResult.SingleOrDefaultAsync();
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(ISpecification<TEntity> specification)
        {
            var specificationResult = ApplySpecification(specification);
            return await specificationResult.FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecification<TEntity> specification)
        {
            var specificationResult = ApplySpecification(specification);
            return await specificationResult.CountAsync();
        }

        public async Task<bool> AnyAsync(ISpecification<TEntity> specification)
        {
            var specificationResult = ApplySpecification(specification);
            return await specificationResult.AnyAsync();
        }

        public void Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete(TKey id)
        {
            var entity = DbContext.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public void DeleteRange(IEnumerable<TKey> ids)
        {
            DbContext.Set<TEntity>().Where(entity => ids.Contains(entity.Id))
                .ToList()
                .ForEach(Delete);
        }

        public void Delete(ISpecification<TEntity> specification)
        {
            var specificationResult = ApplySpecification(specification);
            specificationResult.ToList().ForEach(Delete);
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
        {
            var evaluator = new SpecificationEvaluator<TEntity>();
            return evaluator.GetQuery(DbContext.Set<TEntity>().AsQueryable(), specification);
        }
    }
}