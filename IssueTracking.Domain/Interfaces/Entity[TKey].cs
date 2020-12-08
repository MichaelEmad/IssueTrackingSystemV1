using System;

namespace IssueTracking.Domain.Interfaces
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; protected set; }

        public DateTime CreationDate { get; protected set; }

        public DateTime? ModificationDate { get; protected set; }

        public string CreatedBy { get; protected set; }

        public string ModifiedBy { get; protected set; }

        public int SerialNumber { get; set; }

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
