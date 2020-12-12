using System.Collections.Generic;
using IssueTracking.Application.CQRS;

namespace IssueTracking.Application.Project.Query
{
    public class GetAllProjectsQuery : IQuery<IEnumerable<ProjectDto>>
    {
    }
}
