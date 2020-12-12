using System;
using IssueTracking.Application.CQRS;
using IssueTracking.Domain.Enums;

namespace IssueTracking.Application.Issue.Command
{
    public class CreateIssueCommand : ICommand
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IssueStatus Status { get; set; }

        public IssueType Type { get; set; }

        public Guid ProjectId { get; set; }
    }
}
