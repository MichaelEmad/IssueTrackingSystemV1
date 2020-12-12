using IssueTracking.Application.CQRS;
using IssueTracking.Domain.Enums;

namespace IssueTracking.Application.Issue.Command
{
    public class UpdateIssueStatusCommand : ICommand
    {
        public string Id { get; set; }

        public IssueStatus Status { get; set; }
    }
}
