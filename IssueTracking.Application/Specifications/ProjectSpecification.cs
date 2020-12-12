using System;
using Ardalis.Specification;

namespace IssueTracking.Application.Specifications
{
    public class ProjectSpecification : Specification<Domain.Entities.ProjectAggregate.Project>
    {
        public ProjectSpecification()
        {
            Query.Include(project => project.Owner);
            Query.Include(project => project.Issues);
            Query.Include(project => project.Participants);
        }

        public ProjectSpecification(Guid id) : this()
        {
            Query.Where(project => project.Id == id);
        }
    }
}
