using System;
using System.Collections.Generic;
using System.Text;
using IssueTracking.Application.CQRS;
using IssueTracking.Application.DTO;

namespace IssueTracking.Application.Issue.Query
{
    public class GetAllIssueQuery : IQuery<IEnumerable<IssueDto>>
    {
    }
}
