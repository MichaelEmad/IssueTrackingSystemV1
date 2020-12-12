using System;
using System.Collections.Generic;
using IssueTracking.Application.CQRS;

namespace IssueTracking.Application.Project.Query
{
    public class GetProjectByIdQuery : IQuery<ProjectDto>
    {
        public Guid Id { get; set; }
    }
}
