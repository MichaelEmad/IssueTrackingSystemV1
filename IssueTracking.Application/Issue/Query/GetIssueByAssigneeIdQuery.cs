using System;
using IssueTracking.Application.CQRS;
using IssueTracking.Application.DTO;

namespace IssueTracking.Application.Issue.Query
{
    public class GetIssueByAssigneeIdQuery : IQuery<IssueDto>
    {
        public Guid AssigneeId { get; set; }
    }
}
