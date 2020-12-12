using System;
using IssueTracking.Application.CQRS;

namespace IssueTracking.Application.Issue.Command
{
    public class UpdateIssueAssigneeCommand : ICommand
    {
        public string Id { get; set; }

        public Guid Assignee { get; set; }
    }
}
