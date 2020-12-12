using IssueTracking.Application.CQRS;

namespace IssueTracking.Application.Issue.Command
{
    public class DeleteIssueCommand : ICommand
    {
        public string IssueId { get; set; }
    }
}
