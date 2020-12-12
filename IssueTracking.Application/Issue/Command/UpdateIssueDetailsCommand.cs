using IssueTracking.Application.CQRS;
using IssueTracking.Domain.Enums;

namespace IssueTracking.Application.Issue.Command
{
    public class UpdateIssueDetailsCommand : ICommand
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IssueType Type { get; set; }
    }
}
