using IssueTracking.Domain.Interfaces;

namespace IssueTracking.Domain.Entittes.IssueAggregate
{
    public class Issue : Entity<string>, IAggregateRoot
    {
    }
}
