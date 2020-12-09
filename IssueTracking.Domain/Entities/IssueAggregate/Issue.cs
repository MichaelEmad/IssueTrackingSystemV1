using IssueTracking.Domain.Entities.UserAggregate;
using IssueTracking.Domain.Enums;
using IssueTracking.Domain.Interfaces;
using JetBrains.Annotations;

namespace IssueTracking.Domain.Entities.IssueAggregate
{
    public class Issue : Entity<string>, IAggregateRoot
    {


        public IssueType Type { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public User Reporter { get; private set; }

        [CanBeNull] public User Assignee { get; set; }

        public IssueStatus Status { get; set; }  

        private Issue()
        {

        }

        public Issue(
            IssueType type,
            string title,
            string description,
            User reporter,
            IssueStatus status = IssueStatus.Todo,
            User assignee = null)
        {
            UpdateIssueDetails(type, title, description);
            UpdateIssueStatus(status);
            UpdateAssignee(assignee);
            Reporter = reporter;
        }

        public void UpdateIssueDetails(IssueType type, string title, string description)
        {
            Type = type;
            Title = title;
            Description = description;
        }

        public void UpdateIssueStatus(IssueStatus status)
        {
            Status = status;
        }

        public void UpdateAssignee(User assignee)
        {
            Assignee = assignee;
        }
    }
}
