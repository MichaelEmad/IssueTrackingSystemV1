namespace IssueTracking.Domain.Interfaces
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
