using System;

namespace IssueTracking.Domain.Interfaces
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; protected set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ModificationDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }


        protected Entity()
        {
            HandleGuidPrimaryKeyGeneration();
        }

        private void HandleGuidPrimaryKeyGeneration()
        {
            if (typeof(TKey) == typeof(Guid))
            {
                GetType().GetProperty(nameof(Id)).SetValue(this, Guid.NewGuid());
            }
        }
    }
}
