using System;
using Ardalis.Specification;

namespace IssueTracking.Application.Specifications
{
    public class IssueSpecification : Specification<Domain.Entities.IssueAggregate.Issue>
    {
        public IssueSpecification()
        {
            Query.Include(issue => issue.Project);
            Query.Include(issue => issue.Assignee);
            Query.Include(issue => issue.Reporter);
        }

        public IssueSpecification(string id):this()
        {
            Query.Where(issue => issue.Id == id);
        }

        public void ByAssignId(Guid id)
        {
            Query.Where(issue => issue.Assignee.Id == id);
        }
    }
}
